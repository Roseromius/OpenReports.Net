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
    public class ProducerQA
    {
        [TestMethod]
        public void ProducerModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Producer/Producers.json";
            var producers = new List<Producer>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken producer in rawData["data"].Children())
            {
                Producer tempProducer = producer.ToObject<Producer>();
                Console.WriteLine("Producer Added: " + tempProducer.Name);
                producers.Add(tempProducer);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(producers.Count > 0); //*/

            foreach (Producer producer in producers)
            {
                Assert.IsTrue(producer.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Producer Count: " + producers.Count);

        }

        [TestMethod]
        public void ProducerRequestTest()
        {
            //ARRANGE
            var producers = new List<Producer>();

            //ACT
            producers = (List<Producer>)ProducerController.GetProducers();

            //ASSERT
            Assert.IsNotNull(producers);
            Assert.IsTrue(producers.Count > 0);

            //OUTPUT
            foreach (Producer producer in producers)
            {
                Console.WriteLine("Producer: " + producer.Name);
            }

            Console.WriteLine("Producer Count: " + producers.Count);
        }

        [TestMethod]
        public void ProducerExtractsTest()
        {
            //ARRANGE
            var extracts = new List<Extract>();

            //ACT
            extracts = (List<Extract>)ProducerController.GetProducerExtracts("0000000000VU7TG0000000000");

            //ASSERT
            foreach (Extract extract in extracts)
            {
                Assert.IsNotNull(extract);
                Assert.IsTrue(extract.IsValid());
            }

            //OUTPUT
            foreach (Extract extract in extracts)
            {
                Console.WriteLine("Extract: " + extract.Name);
                Console.WriteLine("-----------------------");
            }
        }

        [TestMethod]
        public void ProducerEdiblesTest()
        {
            //ARRANGE
            var edibles = new List<Edible>();

            //ACT
            edibles = (List<Edible>)ProducerController.GetProducerEdibles("0000000000L6M7E0000000000");

            //ASSERT
            foreach (Edible edible in edibles)
            {
                Assert.IsNotNull(edible);
                Assert.IsTrue(edible.IsValid());
            }

            //OUTPUT
            foreach (Edible edible in edibles)
            {
                Console.WriteLine("Edible: " + edible.Name);
                Console.WriteLine("-----------------------");
            }
        }

        [TestMethod]
        public void ProducerProductsTest()
        {
            //ARRANGE
            var products = new List<Product>();

            //ACT
            products = (List<Product>)ProducerController.GetProducerProducts("0000000000N4E9N0000000000");

            //ASSERT
            foreach (Product product in products)
            {
                Assert.IsNotNull(product);
                Assert.IsTrue(product.IsValid());
            }

            //OUTPUT
            foreach (Product product in products)
            {
                Console.WriteLine("Product: " + product.Name);
                Console.WriteLine("-----------------------");
            }
        }

        [TestMethod]
        public void ProducerAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)ProducerController.GetProducerAvailability
                (
                    "0000000000VU7TG0000000000",
                    37.7749295m,
                    -122.4194155m,
                    25
                );

            //ASSERT
            Assert.IsNotNull(menuItemSummaries);
            Assert.IsTrue(menuItemSummaries.Count > 0);

            foreach (MenuItemSummary summary in menuItemSummaries)
            {
                Assert.IsTrue(summary.IsValid());
            }

            //OUTPUT
            foreach (MenuItemSummary menuItemSummary in menuItemSummaries)
            {
                Console.WriteLine("Name: " + menuItemSummary.Name);
                Console.WriteLine("Lat:"
                    + menuItemSummary.Location.Latitude
                    + " Lon: " + menuItemSummary.Location.Longitude);
                Console.WriteLine("-----------------------------");
            }

            Console.WriteLine("Summary Count: " + menuItemSummaries.Count);

        }
    }
}
