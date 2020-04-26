using LoyaltyCard.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoyaltyCard.Data
{
    public class LoyaltyCardDataAccess
    {
        string pathFile;
        public LoyaltyCardDataAccess()
        {
            pathFile = Environment.CurrentDirectory + "\\JsonDatabase\\" + typeof(LoyaltyCardModel).Name + ".json";
            if (!File.Exists(pathFile))
            {
                var file = File.Create(pathFile);
                file.Close();
            }

        }
        public void SaveToDatabase(LoyaltyCardModel model)
        {
            //do save to db
            var allData = Helper.ReadDataFromJson<LoyaltyCardModel>(pathFile);
            allData.Add(model);
            Helper.SaveDataToJson(pathFile, allData);
        }

        public IEnumerable<LoyaltyCardModel> LoadData()
        {
            //do load from db
            return Helper.ReadDataFromJson<LoyaltyCardModel>(pathFile);
        }

        public void UpdateRecord(LoyaltyCardModel model)
        {
            var allData = Helper.ReadDataFromJson<LoyaltyCardModel>(pathFile);
            var updateModel = allData.Find(x => x.ID == model.ID);
            updateModel = model;
            Helper.SaveDataToJson(pathFile, allData);
        }

        public LoyaltyCardModel GetLoyaltyCardByID(string Id)
        {
            return LoadData().FirstOrDefault(x => x.ID == Id);
        }
    }
}
