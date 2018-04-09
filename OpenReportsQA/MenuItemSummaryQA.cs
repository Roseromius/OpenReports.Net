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
    public class MenuItemSummaryQA
    {
        [TestMethod]
        public void MenuItemSummaryModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/MenuItemSummary.json";


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);
            MenuItemSummary menuItemSummary = rawData["data"].ToObject<MenuItemSummary>();


            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(menuItemSummary.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + menuItemSummary.Name);
            Console.WriteLine("Price: " + menuItemSummary.Price);
            Console.WriteLine("Type: " + menuItemSummary.Type);
            Console.WriteLine("------------------------");
        }
    }
}
