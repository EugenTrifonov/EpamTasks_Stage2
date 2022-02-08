using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace Task5.Utilities
{
    public class DataReeder
    {
        private static readonly string _dataPath = "../../../../../Task5/Task5/Resources/";
        private static string _enviroment = TestContext.Parameters["environment"];

        public static string GetDataFromJsonByKey(string key)
        {

            JObject json = JObject.Parse(File.ReadAllText(_dataPath + _enviroment + ".json"));

            return json.Descendants()
                .OfType<JProperty>()
                .Where(x => x.Name == key)
                .First()
                .Value
                .ToString();
        }
    }
}
