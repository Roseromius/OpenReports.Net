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
    public class EdiblesQA
    {
        [TestMethod]
        public void EdibleModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Edible/Edibles.json";
            var edibles = new List<Edible>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken edible in rawData["data"].Children())
            {
                Edible tempEdible = edible.ToObject<Edible>();
                Console.WriteLine("Edible Added: " + tempEdible.Name);
                edibles.Add(tempEdible);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(edibles.Count > 0); //*/

            foreach (Edible edible in edibles)
            {
                Assert.IsTrue(edible.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Edible Count: " + edibles.Count);

        }

        [TestMethod]
        public void EdibleRequestTest()
        {
            //ARRANGE
            var edibles = new List<Edible>();

            //ACT
            edibles = (List<Edible>)EdibleController.GetEdibles();

            //ASSERT
            Assert.IsNotNull(edibles);
            Assert.IsTrue(edibles.Count > 0);

            //OUTPUT
            foreach (Edible edible in edibles)
            {
                Console.WriteLine("Edible: " + edible.Name);
            }

            Console.WriteLine("Edible Count: " + edibles.Count);
        }

        [TestMethod]
        public void EdibleByTypeTest()
        {
            //ARRANGE
            var edibles = new List<Edible>();

            //ACT
            edibles = (List<Edible>)EdibleController.GetEdibleByType(SecondaryObjectType.Chocolate);

            //ASSERT
            Assert.IsNotNull(edibles);
            Assert.IsTrue(edibles.Count > 0);

            //OUTPUT
            foreach (Edible edible in edibles)
            {
                Console.WriteLine("Edible: " + edible.Name);
                Console.WriteLine("THC: " + edible.THC);
                Console.WriteLine("CBD: " + edible.CBD);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Edible Count: " + edibles.Count);
        }

        [TestMethod]
        public void SingleEdibleRequestTest()
        {
            //ARRANGE
            var edible = new Edible();

            //ACT
            edible = EdibleController.GetEdible("4KXM32V9YFC3G2EUNWP400000");

            //ASSERT
            Assert.IsNotNull(edible);
            Assert.IsTrue(edible.IsValid());
            Assert.IsTrue(edible.Name == "Soda - Girl Scout Cookies and Cream");

            //OUTPUT
            Console.WriteLine("Edible: " + edible.Name);
        }

        [TestMethod]
        public void EdibleUserTest()
        {
            //ARRANGE
            var user = new User();

            //ACT
            user = EdibleController.GetEdibleUser("4KXM32V9YFC3G2EUNWP400000");

            //ASSERT
            Assert.IsNotNull(user); ;
            Assert.IsTrue(user.IsValid());
            Assert.IsTrue(user.Nickname == "Untamed Dame");

            //OUTPUT
            Console.WriteLine("Name: " + user.Nickname);
        }

        [TestMethod]
        public void EdibleReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)EdibleController.GetEdibleReviews("0000000000L6M7ENLJVX00000", 1);

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
        public void EdibleEffectsAndFlavorsTest()
        {
            //ARRANGE
            var effectsAndFlavors = new EffectsAndFlavors();

            //ACT
            effectsAndFlavors = EdibleController.GetEdibleEffectsFlavors("0000000000L6M7ENLJVX00000");

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
        public void EdibleProducerTest()
        {
            //ARRANGE
            var producer = new Producer();

            //ACT
            producer = EdibleController.GetEdibleProducer("0000000000L6M7ENLJVX00000");

            //ASSERT
            Assert.IsNotNull(producer);
            Assert.IsTrue(producer.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + producer.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void EdibleStrainTest()
        {
            //ARRANGE
            var strain = new Strain();

            //ACT
            strain = EdibleController.GetEdibleStrain("4KXM32V9YFC3G2EUNWP400000");

            //ASSERT
            Assert.IsNotNull(strain);
            Assert.IsTrue(strain.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + strain.Name);
            Console.WriteLine("Seed Company: " + strain.SeedCompany.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void EdibleAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)EdibleController.GetEdibleAvailability
                (
                    "4KXM32V9YFC3G2EUNWP400000",
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
