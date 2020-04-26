using LoyaltyCard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyCard.Logic
{
    public class ProcessTransactionLogic
    {
        TransactionDataAccess _transactionDA;
        LoyaltyCardDataAccess _loyaltyCardDataAccess;
        public ProcessTransactionLogic()
        {
            _transactionDA = new TransactionDataAccess();
            _loyaltyCardDataAccess = new LoyaltyCardDataAccess();
        }
        public void ToProcessingTransaction()
        {
            var toProcessingTransactions = _transactionDA.LoadData().Where(x => x.TransactionState == TransactionState.QUEUE);
            foreach (var transaction in toProcessingTransactions)
            {
                transaction.TransactionState = TransactionState.PROCESSING;
                _transactionDA.UpdateRecord(transaction);
            }
        }

        public void ProcessTransaction()
        {
            var transactionByCardIDs = _transactionDA.LoadData().Where(x => x.TransactionState == TransactionState.PROCESSING).GroupBy(x => x.LoyaltyCardID);
            foreach (var cardID in transactionByCardIDs)
            {
                var loyaltyCard = _loyaltyCardDataAccess.GetLoyaltyCardByID(cardID.Key);
                var totalSpent = cardID.Sum(x => (decimal)x.SpentAdjust);
                loyaltyCard.LoyaltyCartTypeId = GetCartTypeByTotalSpent(totalSpent);
                loyaltyCard.TotalSpent = totalSpent;
                _loyaltyCardDataAccess.UpdateRecord(loyaltyCard);

                Task.Run(() => UpdateDoneTransactionProcess(cardID));
            }
        }

        public uint GetCartTypeByTotalSpent(decimal totalSpent)
        {
            if (totalSpent < 5000000)
                return 1;

            if (totalSpent < 10000000)
                return 2;

            if (totalSpent < 20000000)
                return 3;

            if (totalSpent < 50000000)
                return 4;

            if (totalSpent >= 50000000)
                return 5;

            return 1;
        }

        void UpdateDoneTransactionProcess(IEnumerable<TransactionModel> listDoneTransaction)
        {
            foreach (var transaction in listDoneTransaction)
            {
                transaction.TransactionState = TransactionState.DONE;
                _transactionDA.UpdateRecord(transaction);
            }
        }
    }
}
