using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenReportsQA
{
    [TestClass]
    public class MenuItemQA
    {
        [TestMethod]
        public void MenuItemModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/MenuItems.json";
            var menuItems = new List<MenuItem>();

            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            foreach (JObject menuItem in rawData["data"].Children())
            {
                menuItems.Add(menuItem.ToObject<MenuItem>());
            }
            
            //ASSERT
            Assert.IsNotNull(json);

            foreach (MenuItem menuItem in menuItems)
            {
                Assert.IsTrue(menuItem.IsValid());
            }

            //OUTPUT
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("Name: " + menuItem.Name);
                Console.WriteLine("Price: " + menuItem.Price);
                Console.WriteLine("Type: " + menuItem.Type);
                Console.WriteLine("------------------------");
            }

        }
    }
}
