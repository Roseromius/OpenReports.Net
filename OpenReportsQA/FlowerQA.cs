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
    public class FlowerQA
    {
        [TestMethod]
        public void FlowerModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Flower/Flowers.json";
            var flowers = new List<Flower>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken flower in rawData["data"].Children())
            {
                Flower tempFlower = flower.ToObject<Flower>();
                Console.WriteLine("Flower Added: " + tempFlower.Name);
                flowers.Add(tempFlower);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(flowers.Count > 0); //*/

            foreach (Flower flower in flowers)
            {
                Assert.IsTrue(flower.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Flower Count: " + flowers.Count);

        }

        [TestMethod]
        public void FlowerRequestTest()
        {
            //ARRANGE
            var flowers = new List<Flower>();

            //ACT
            flowers = (List<Flower>)FlowerController.GetFlowers();

            //ASSERT
            Assert.IsNotNull(flowers);
            Assert.IsTrue(flowers.Count > 0);

            //OUTPUT
            foreach (Flower flower in flowers)
            {
                Console.WriteLine("Flower: " + flower.Name);
            }

            Console.WriteLine("Flower Count: " + flowers.Count);
        }

        [TestMethod]
        public void FlowersByTypeTest()
        {
            //ARRANGE
            var flowers = new List<Flower>();

            //ACT
            flowers = (List<Flower>)FlowerController.GetFlowerByType(SecondaryObjectType.Seeds);

            //ASSERT
            Assert.IsNotNull(flowers);
            Assert.IsTrue(flowers.Count > 0);

            //OUTPUT
            foreach (Flower flower in flowers)
            {
                Console.WriteLine("Flower: " + flower.Name);
                Console.WriteLine("THC: " + flower.Thc);
                Console.WriteLine("CBD: " + flower.Cbd);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Flower Count: " + flowers.Count);
        }

        [TestMethod]
        public void SingleFlowerRequestTest()
        {
            //ARRANGE
            var flower = new Flower();

            //ACT
            flower = (Flower)FlowerController.GetFlower("9XVU7FNY7ZMW2KZQTVNR00000");

            //ASSERT
            Assert.IsNotNull(flower);
            Assert.IsTrue(flower.IsValid());
            Assert.IsTrue(flower.Name == "Key Lime Pie - Flowers");

            //OUTPUT
            Console.WriteLine("Flower: " + flower.Name);
        }

        [TestMethod]
        public void FlowerUserTest()
        {
            //ARRANGE
            var user = new User();

            //ACT
            user = (User)FlowerController.GetFlowerUser("AHZ7H4N6467FVUDY3DAY00000");

            //ASSERT
            Assert.IsNotNull(user); ;
            Assert.IsTrue(user.IsValid());
            Assert.IsTrue(user.Nickname == "jbcrockett");

            //OUTPUT
            Console.WriteLine("Name: " + user.Nickname);
        }

        [TestMethod]
        public void FlowerReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)FlowerController.GetFlowerReviews("AHZ7H4N6467FVUDY3DAY00000", 1);

            //ASSERT
            Assert.IsNotNull(reviews);

            foreach (Review review in reviews)
            {
                Assert.IsTrue(review.IsValid());
            }

            Assert.IsTrue(reviews.Count > 0);

            //OUTPUT
            foreach (Review review in reviews)
            {
                Console.WriteLine("Appetite Gain: " + review.AppetiteGain);
                Console.WriteLine("Pain Relief: " + review.PainRelief);
                Console.WriteLine("Dry Mouth: " + review.DryMouth);
                Console.WriteLine("------------------------");
            }
        }

        [TestMethod]
        public void FlowerEffectsAndFlavorsTest()
        {
            //ARRANGE
            var effectsAndFlavors = new EffectsAndFlavors();

            //ACT
            effectsAndFlavors = (EffectsAndFlavors)FlowerController.GetFlowerEffectsFlavors("AHZ7H4N6467FVUDY3DAY00000");

            //ASSERT
            Assert.IsNotNull(effectsAndFlavors);
            Assert.IsTrue(effectsAndFlavors.IsValid());

            //OUTPUT
            Console.WriteLine("Appetite Gain: " + effectsAndFlavors.AppetiteGain);
            Console.WriteLine("Anxiety: " + effectsAndFlavors.Anxiety);
            Console.WriteLine("Dry Mouth: " + effectsAndFlavors.DryMouth);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void FlowerProducerTest()
        {
            //ARRANGE
            var producer = new Producer();

            //ACT
            producer = (Producer)FlowerController.GetFlowerProducer("AHZ7H4N6467FVUDY3DAY00000");

            //ASSERT
            Assert.IsNotNull(producer);
            Assert.IsTrue(producer.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + producer.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void FlowerStrainTest()
        {
            //ARRANGE
            var strain = new Strain();

            //ACT
            strain = (Strain)FlowerController.GetFlowerStrain("AHZ7H4N6467FVUDY3DAY00000");

            //ASSERT
            Assert.IsNotNull(strain);
            Assert.IsTrue(strain.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + strain.Name);
            Console.WriteLine("Seed Company: " + strain.SeedCompany.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void FlowerAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)FlowerController.GetFlowerAvailability("YYRZDWGVU22WJVPGDJ7J00000", 37.7749295m, -122.4194155m, 10);

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
