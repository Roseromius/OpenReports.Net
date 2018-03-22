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
    public class UserQA
    {
        [TestMethod]
        public void UserModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/User.json";
            var user = new User();


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            User userObject = rawData["data"].ToObject<User>();

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(userObject.IsValid());
            

            //OUTPUT
            Console.WriteLine("Name: " + userObject.Nickname);

        }
    }
}
