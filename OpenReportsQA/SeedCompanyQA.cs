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
    }
}
