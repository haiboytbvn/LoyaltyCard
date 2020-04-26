using LoyaltyCard.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoyaltyCard.Data
{
    public class RatioConfigDataAccess
    {
        string pathFile;
        public RatioConfigDataAccess()
        {
            pathFile = System.Environment.CurrentDirectory + "\\JsonDatabase\\" + typeof(RatioConfigModel).Name + ".json";
            if (!File.Exists(pathFile))
            {
                var file = File.Create(pathFile);
                file.Close();
            }
        }
        public RatioConfigModel GetCurrentData()
        {
            var data = Helper.ReadDataFromJson<RatioConfigModel>(pathFile).FirstOrDefault();
            if(data == null)
            {
                data = CreateDefaultValue();
            }
            return data;
        }

        public void ChangeValue(RatioConfigModel newdata)
        {
            Helper.SaveDataToJson(pathFile, new List<RatioConfigModel>() { newdata });
        }

        public RatioConfigModel CreateDefaultValue()
        {
            var defaultData = new RatioConfigModel() { RatioValue = 0 };
            ChangeValue(defaultData);
            return defaultData;
        }
    }
}
