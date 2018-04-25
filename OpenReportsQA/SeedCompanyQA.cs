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
    public class SeedCompanyQA
    {
        [TestMethod]
        public void SeedCompanyModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/SeedCompany/SeedCompany.json";


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);
            SeedCompany seedCompany = rawData["data"].ToObject<SeedCompany>();


            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(seedCompany.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + seedCompany.Name);
        }

        [TestMethod]
        public void SingleSeedCompanyRequestTest()
        {
            //ARRANGE
            var seedCpmpany = new SeedCompany();

            //ACT
            seedCpmpany = SeedCompanyController.GetSeedCompany("VUJCJ00000000000000000000");

            //ASSERT
            Assert.IsNotNull(seedCpmpany);
            Assert.IsTrue(seedCpmpany.IsValid());
            Assert.IsTrue(seedCpmpany.Name == "Sensi Seeds");

            //OUTPUT
            Console.WriteLine("SeedCompany: " + seedCpmpany.Name);
        }

        [TestMethod]
        public void SeedCompanyStrainsTest()
        {
            //ARRANGE
            var strains = new List<Strain>();

            //ACT
            strains = (List<Strain>)SeedCompanyController.GetSeedCompanyStrains("6FAFX00000000000000000000", 1);

            //ASSERT
            Assert.IsNotNull(strains);

            foreach (Strain review in strains)
            {
                Assert.IsTrue(review.IsValid());
            }

            Assert.IsTrue(strains.Count > 0);

            //OUTPUT
            foreach (Strain strain in strains)
            {
                Console.WriteLine("Name: " + strain.Name);
                Console.WriteLine("Seed Company: " + strain.SeedCompany.Name);
                Console.WriteLine("------------------------");
            }
        }

        [TestMethod]
        public void SeedCompanyReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)SeedCompanyController.GetSeedCompanyReviews("VUJCJ00000000000000000000", 1);

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
    }
}
