using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace OpenReportsQA
{
    [TestClass]
    public class StrainQA
    {
        [TestMethod]
        public void StrainModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Strains/Strains.json";
            var strains = new List<Strain>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken strain in rawData["data"].Children())
            {
                Strain tempStrain = strain.ToObject<Strain>();
                Console.WriteLine("Strain Added: " + tempStrain.Name);
                strains.Add(tempStrain);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(strains.Count > 0); //*/

            //OUTPUT
            Console.WriteLine("Strain Count: " + strains.Count);

        }

        [TestMethod]
        public void StrainRequestTest()
        {
            //ARRANGE
            var strains = new List<Strain>();


            //ACT
            strains = (List<Strain>)StrainController.GetStrains();

            //ASSERT
            Assert.IsNotNull(strains);
            Assert.IsTrue(strains.Count > 0);

            //OUTPUT
            foreach (Strain strain in strains)
            {
                Console.WriteLine("Strain: " + strain.Name);
            }

            Console.WriteLine("Strain Count: " + strains.Count);
        }

        [TestMethod]
        public void SingleStrainRequestTest()
        {
            //ARRANGE
            var strain = new Strain();

            //ACT
            strain = (Strain)StrainController.GetStrain("VUJCJ4TYMG000000000000000");

            //ASSERT
            Assert.IsNotNull(strain);
            Assert.IsTrue(strain.IsValid());
            Assert.IsTrue(strain.Name == "Jack Herer");

            //OUTPUT
            Console.WriteLine("Strain: " + strain.Name);
        }

        [TestMethod]
        public void LookupStrainTest()
        {
            //ARRANGE
            var strains = new List<Strain>();
            var lookupText = "Blue";


            //ACT
            strains = (List<Strain>)StrainController.LookupStrain(lookupText);

            //ASSERT
            Assert.IsNotNull(strains);
            Assert.IsTrue(strains.Count > 0);
            foreach (Strain strain in strains)
            {
                Assert.IsTrue(strain.Name.Contains("Blue"));
            }

            //OUTPUT
            foreach (Strain strain in strains)
            {
                Console.WriteLine("Strain: " + strain.Name);
            }

            Console.WriteLine("Strain Count: " + strains.Count);
        }

        [TestMethod]
        public void StrainUserTest()
        {
            //ARRANGE
            var user = new User();

            //ACT
            user = (User)StrainController.GetStrainUser("VUJCJ4TYMG000000000000000");

            //ASSERT
            Assert.IsNotNull(user); ;
            Assert.IsTrue(user.IsValid());
            Assert.IsTrue(user.Nickname == "David");

            //OUTPUT
            Console.WriteLine("Name: " + user.Nickname);
        }

        [TestMethod]
        public void StrainReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)StrainController.GetStrainReviews("VUJCJ4TYMG000000000000000",1);

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
        public void StrainEffectsAndFlavorsTest()
        {
            //ARRANGE
            var effectsAndFlavors = new EffectsAndFlavors();

            //ACT
            effectsAndFlavors = (EffectsAndFlavors)StrainController.GetStrainEffectsFlavors("VUJCJ4TYMG000000000000000");

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
        public void StrainSeedCompanyTest()
        {
            //ARRANGE
            var seedCompany = new SeedCompany();

            //ACT
            seedCompany = (SeedCompany)StrainController.GetStrainSeedCompany("VUJCJ4TYMG000000000000000");

            //ASSERT
            Assert.IsNotNull(seedCompany);
            Assert.IsTrue(seedCompany.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + seedCompany.Name);
        }

        [TestMethod]
        public void StrainGeneticsTest()
        {
            //ARRANGE
            var strains = new List<Strain>();

            //ACT
            strains = (List<Strain>)StrainController.GetStrainGenetics("VUJCJ4TYMG000000000000000");

            //ASSERT
            Assert.IsNotNull(strains);
            Assert.IsTrue(strains.Count > 0);

            //OUTPUT
            foreach (Strain strain in strains)
            {
                Console.WriteLine("Strain: " + strain.Name);
            }

            Console.WriteLine("Strain Count: " + strains.Count);
        }

        [TestMethod]
        public void StrainChildrenTest()
        {
            //ARRANGE
            var strains = new List<Strain>();

            //ACT
            strains = (List<Strain>)StrainController.GetStrainChildren("VUJCJ4TYMG000000000000000", 1);

            //ASSERT
            Assert.IsNotNull(strains);
            Assert.IsTrue(strains.Count > 0);

            //OUTPUT
            foreach (Strain strain in strains)
            {
                Console.WriteLine("Strain: " + strain.Name);
            }

            Console.WriteLine("Strain Count: " + strains.Count);
        }

        [TestMethod]
        public void StrainAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)StrainController.GetStrainAvailability("VUJCJ4TYMG000000000000000", 37.7749295m, -122.4194155m,10);

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
