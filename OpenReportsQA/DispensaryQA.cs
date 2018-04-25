using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OpenReportsQA
{
    [TestClass]
    public class DispensaryQA
    {
        [TestMethod]
        public void DispensaryModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Dispensary/Dispensaries.json";
            var dispensaries = new List<Dispensary>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken dispensary in rawData["data"].Children())
            {
                Dispensary tempDispensary = dispensary.ToObject<Dispensary>();
                Console.WriteLine("Dispensary Added: " + tempDispensary.Name);
                dispensaries.Add(tempDispensary);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(dispensaries.Count > 0); //*/

            foreach (Dispensary dispensary in dispensaries)
            {
                Assert.IsTrue(dispensary.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Dispensary Count: " + dispensaries.Count);

        }

        [TestMethod]
        public void DispensaryRequestTest()
        {
            //ARRANGE
            var dispensaries = new List<Dispensary>();

            //ACT
            dispensaries = (List<Dispensary>)DispensaryController.GetDispensaries();

            //ASSERT
            Assert.IsNotNull(dispensaries);
            Assert.IsTrue(dispensaries.Count > 0);

            //OUTPUT
            foreach (Dispensary dispensary in dispensaries)
            {
                Console.WriteLine("Dispensary: " + dispensary.Name);
            }

            Console.WriteLine("Dispensary Count: " + dispensaries.Count);
        }

        [TestMethod]
        public void SingleDispensaryRequestTest()
        {
            //ARRANGE
            var dispensary = new Dispensary();

            //ACT
            dispensary = DispensaryController.GetDispensary("ca", "san-francisco", "grass-roots");

            //ASSERT
            Assert.IsNotNull(dispensary);
            Assert.IsTrue(dispensary.IsValid());
            Assert.IsTrue(dispensary.Name == "Grass Roots");

            //OUTPUT
            Console.WriteLine("Dispensary: " + dispensary.Name);
        }

        [TestMethod]
        public void DispensaryStrainMenuItemsTest()
        {
            //ARRANGE
            var menuItems = new List<MenuItem>();

            //ACT
            menuItems = (List<MenuItem>)DispensaryController.GetDispensaryStrainMenuItems("ca", "san-francisco", "grass-roots");

            //ASSERT
            Assert.IsNotNull(menuItems);
            Assert.IsTrue(menuItems.Count > 0);

            //OUTPUT
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("MenuItem: " + menuItem.Name);
            }

            Console.WriteLine("MenuItems Count: " + menuItems.Count);
        }

        [TestMethod]
        public void DispensaryExtractMenuItemsTest()
        {
            //ARRANGE
            var menuItems = new List<MenuItem>();

            //ACT
            menuItems = (List<MenuItem>)DispensaryController.GetDispensaryExtractMenuItems
                (
                    "ca",
                    "san-francisco",
                    "grass-roots"
                );

            //ASSERT
            Assert.IsNotNull(menuItems);
            Assert.IsTrue(menuItems.Count > 0);

            //OUTPUT
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("MenuItem: " + menuItem.Name);
            }

            Console.WriteLine("MenuItems Count: " + menuItems.Count);
        }

        [TestMethod]
        public void DispensaryEdibleMenuItemsTest()
        {
            //ARRANGE
            var menuItems = new List<MenuItem>();

            //ACT
            menuItems = (List<MenuItem>)DispensaryController.GetDispensaryEdiblesMenuItems
                (
                    "ca",
                    "san-francisco",
                    "grass-roots"
                );

            //ASSERT
            Assert.IsNotNull(menuItems);
            Assert.IsTrue(menuItems.Count > 0);

            //OUTPUT
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("MenuItem: " + menuItem.Name);
            }

            Console.WriteLine("MenuItems Count: " + menuItems.Count);
        }

        [TestMethod]
        public void DispensaryProductMenuItemsTest()
        {
            //ARRANGE
            var menuItems = new List<MenuItem>();

            //ACT
            menuItems = (List<MenuItem>)DispensaryController.GetDispensaryProductMenuItems
                (
                    "ca",
                    "san-francisco",
                    "grass-roots"
                );

            //ASSERT
            Assert.IsNotNull(menuItems);
            Assert.IsTrue(menuItems.Count > 0);

            //OUTPUT
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine("MenuItem: " + menuItem.Name);
            }

            Console.WriteLine("MenuItems Count: " + menuItems.Count);
        }
    }
}
