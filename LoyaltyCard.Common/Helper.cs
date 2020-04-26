using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LoyaltyCard.Common
{
    public static class Helper
    {
        public static void SaveDataToJson(string filePath, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonData);
        }

        public static List<T> ReadDataFromJson<T>(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            List<T> obj;
            obj = JsonConvert.DeserializeObject<List<T>>(jsonData);
            if (obj == null)
            {
                obj = new List<T>();
            }
            return obj;
        }
    }
}
