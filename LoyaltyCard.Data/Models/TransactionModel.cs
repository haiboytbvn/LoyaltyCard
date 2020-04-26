using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyCard.Data
{
    public class TransactionModel : BaseModel
    {
        public string LoyaltyCardID { get; set; }
        public ulong PointAdjust { get; set; }
        public ulong SpentAdjust { get; set; }
        public TransactionState TransactionState { get; set; }
    }

    public enum TransactionState { QUEUE, PROCESSING, DONE }
}
