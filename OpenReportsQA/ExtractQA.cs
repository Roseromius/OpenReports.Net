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
    public class ExtractQA
    {
        [TestMethod]
        public void ExtractModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Extract/Extracts.json";
            var extracts = new List<Extract>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken extract in rawData["data"].Children())
            {
                Extract tempExtract = extract.ToObject<Extract>();
                Console.WriteLine("Extract Added: " + tempExtract.Name);
                extracts.Add(tempExtract);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(extracts.Count > 0); //*/

            foreach (Extract extract in extracts)
            {
                Assert.IsTrue(extract.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Extract Count: " + extracts.Count);

        }

        [TestMethod]
        public void ExtractRequestTest()
        {
            //ARRANGE
            var extracts = new List<Extract>();

            //ACT
            extracts = (List<Extract>)ExtractController.GetExtracts();

            //ASSERT
            Assert.IsNotNull(extracts);
            Assert.IsTrue(extracts.Count > 0);

            //OUTPUT
            foreach (Extract extract in extracts)
            {
                Console.WriteLine("Extract: " + extract.Name);
            }

            Console.WriteLine("Extract Count: " + extracts.Count);
        }

        [TestMethod]
        public void ExtractByTypeTest()
        {
            //ARRANGE
            var extracts = new List<Extract>();

            //ACT
            extracts = (List<Extract>)ExtractController.GetExtractByType(SecondaryObjectType.Shatter);

            //ASSERT
            Assert.IsNotNull(extracts);
            Assert.IsTrue(extracts.Count > 0);

            //OUTPUT
            foreach (Extract extract in extracts)
            {
                Console.WriteLine("Extract: " + extract.Name);
                Console.WriteLine("THC: " + extract.THC);
                Console.WriteLine("CBD: " + extract.CBD);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Extract Count: " + extracts.Count);
        }

        [TestMethod]
        public void SingleExtractRequestTest()
        {
            //ARRANGE
            var extract = new Extract();

            //ACT
            extract = ExtractController.GetExtract("9XVU74QKE6UK4P69XKZH00000");

            //ASSERT
            Assert.IsNotNull(extract);
            Assert.IsTrue(extract.IsValid());
            Assert.IsTrue(extract.Name == "Blue Berry - Wax");

            //OUTPUT
            Console.WriteLine("Extract: " + extract.Name);
        }

        [TestMethod]
        public void ExtractUserTest()
        {
            //ARRANGE
            var user = new User();

            //ACT
            user = ExtractController.GetExtractUser("QLG39RN2AFPMR6WLTPLW00000");

            //ASSERT
            Assert.IsNotNull(user); ;
            Assert.IsTrue(user.IsValid());
            Assert.IsTrue(user.Nickname == "Untamed Dame");

            //OUTPUT
            Console.WriteLine("Name: " + user.Nickname);
        }

        [TestMethod]
        public void ExtractReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)ExtractController.GetExtractReviews("9XVU762EQ4VU7TG3N9NM00000", 1);

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
        public void ExtractEffectsAndFlavorsTest()
        {
            //ARRANGE
            var effectsAndFlavors = new EffectsAndFlavors();

            //ACT
            effectsAndFlavors = ExtractController.GetExtractEffectsFlavors("9XVU74QKE6UK4P69XKZH00000");

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
        public void ExtractProducerTest()
        {
            //ARRANGE
            var producer = new Producer();

            //ACT
            producer = ExtractController.GetExtractProducer("9XVU74QKE6UK4P69XKZH00000");

            //ASSERT
            Assert.IsNotNull(producer);
            Assert.IsTrue(producer.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + producer.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void ExtractStrainTest()
        {
            //ARRANGE
            var strain = new Strain();

            //ACT
            strain = ExtractController.GetExtractStrain("9XVU74QKE6UK4P69XKZH00000");

            //ASSERT
            Assert.IsNotNull(strain);
            Assert.IsTrue(strain.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + strain.Name);
            Console.WriteLine("Seed Company: " + strain.SeedCompany.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void ExtractAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)ExtractController.GetExtractAvailability
                (
                    "9XVU7GMTKCHNWPT6WGRR00000",
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
