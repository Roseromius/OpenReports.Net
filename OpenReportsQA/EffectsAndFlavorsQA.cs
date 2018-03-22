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
    public class EffectsAndFlavorsQA
    {
        [TestMethod]
        public void EffectsAndFlavorsModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Other/EffectsAndFlavors.json";


            //ACT
            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);
            EffectsAndFlavors effectsAndFlavors = rawData["data"].ToObject<EffectsAndFlavors>();


            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(effectsAndFlavors.IsValid());

            //OUTPUT
            Console.WriteLine("Appetite Gain: " + effectsAndFlavors.AppetiteGain);
            Console.WriteLine("Anxiety: " + effectsAndFlavors.Anxiety);
            Console.WriteLine("Dry Mouth: " + effectsAndFlavors.DryMouth);
            Console.WriteLine("------------------------");
        }
    }
}
