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
            string path = "JSON/Producer/Producer.json";


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            Producer producer = rawData["data"].ToObject<Producer>();

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(producer.IsValid()); //*/

            //OUTPUT
            Console.WriteLine("Producer Name: " + producer.Name);

        }
    }
}
