using LoyaltyCard.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoyaltyCard.Data
{
    public class TransactionDataAccess
    {
        string pathFile;
        public TransactionDataAccess()
        {
            pathFile = Environment.CurrentDirectory + "\\JsonDatabase\\" + typeof(TransactionModel).Name + ".json";
            if (!File.Exists(pathFile))
            {
                var file = File.Create(pathFile);
                file.Close();
            }

        }
        public void SaveToDatabase(TransactionModel model)
        {
            //do save to db
            var allData = Helper.ReadDataFromJson<TransactionModel>(pathFile);
            allData.Add(model);
            Helper.SaveDataToJson(pathFile, allData);
        }

        public IEnumerable<TransactionModel> LoadData()
        {
            //do load from db
            return Helper.ReadDataFromJson<TransactionModel>(pathFile);
        }

        public void UpdateRecord(TransactionModel model)
        {
            var allData = Helper.ReadDataFromJson<TransactionModel>(pathFile);
            var updateModel = allData.Find(x => x.ID == model.ID);
            updateModel = model;
            Helper.SaveDataToJson(pathFile, allData);
        }
    }
}
