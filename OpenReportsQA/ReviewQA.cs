using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenReportsQA
{
    [TestClass]
    public class ReviewQA
    {
        [TestMethod]
        public void ReviewModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/Reviews.json";
            var reviews = new List<Review>();


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            foreach (JToken token in rawData["data"].Children())
            {
                Review tempReview = token.ToObject<Review>();
                reviews.Add(tempReview);
            }
            

            //ASSERT
            Assert.IsNotNull(json);

            foreach (Review review in reviews)
            {
                Assert.IsTrue(review.IsValid());

                //OUTPUT
                Console.WriteLine("Appetite Gain: " + review.AppetiteGain);
                Console.WriteLine("Pain Relief: " + review.PainRelief);
                Console.WriteLine("Dry Mouth: " + review.DryMouth);
                Console.WriteLine("------------------------");
            }
            




        }
    }
}
