using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenReportsQA
{
    [TestClass]
    public class ItemQA
    {
        [TestMethod]
        public void ItemModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/Item.json";


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);
            Item item = rawData["data"].ToObject<Item>();


            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(item.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + item.Name);
            Console.WriteLine("Type: " + item.Type);
            Console.WriteLine("------------------------");

        }
    }
}
