using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenReports.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReportsQA
{
    [TestClass]
    public class FunctionsQA
    {
        [TestMethod]
        public void UrlGeneratorTest()
        {
            //ARRANGE
            var urlGenerator = new UrlGenerator();


            //ACT
            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Strain, "ucpcgoeshere");

            //ASSERT
            Assert.IsNotNull(urlGenerator.URL);
            Assert.IsTrue(urlGenerator.URL.Length > 0);

            //OUTPUT
            Console.WriteLine(urlGenerator.URL);

        }

        [TestMethod]
        public void UCPCParseTest()
        {
            //ARRANGE
            var ucpc = new UCPC("CYGU94JYKYUY9V7TAFL200000",PrimaryObjectType.Strain);
            var ucpc2 = new UCPC("CYGU94JYKYUY9V7TAFL200000", PrimaryObjectType.SeedCompany);
            var ucpc3 = new UCPC("CYGU94JYKYUY9V7TAFL200000", PrimaryObjectType.Producer);
            var ucpc4 = new UCPC("CYGU94JYKYUY9V7TAFL200000", PrimaryObjectType.Product);
            var ucpc5 = new UCPC("CYGU94JYKYUY9V7TAFL200000", PrimaryObjectType.Batch);

            //ACT

            //ASSERT

            Assert.IsTrue(ucpc.IsValid());
            Assert.IsTrue(!ucpc.HasErrors);
            Assert.IsTrue(ucpc.SeedCompanyCode == "CYGU900000000000000000000");
            Assert.IsTrue(ucpc.StrainCode == "000004JYKY000000000000000");
            Assert.IsTrue(ucpc.ProducerCode == "0000000000UY9V70000000000");
            Assert.IsTrue(ucpc.ProductCode == "000000000000000TAFL200000");
            Assert.IsTrue(ucpc.BatchCode == "0000000000000000000000000");

            Assert.IsTrue(ucpc2.IsValid());
            Assert.IsTrue(!ucpc2.HasErrors);

            Assert.IsTrue(ucpc3.IsValid());
            Assert.IsTrue(!ucpc3.HasErrors);

            Assert.IsTrue(ucpc4.IsValid());
            Assert.IsTrue(!ucpc4.HasErrors);

            Assert.IsTrue(ucpc5.IsValid()); 
            Assert.IsTrue(ucpc5.HasErrors);//BATCH SHOULD HAVE ERRORS

            //OUTPUT
            Console.WriteLine("UCPC Code:" + ucpc.Code);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Seed Company: " + ucpc.SeedCompanyCode);
            Console.WriteLine("Strain : " + ucpc.StrainCode);
            Console.WriteLine("Producer: " + ucpc.ProducerCode);
            Console.WriteLine("Product: " + ucpc.ProductCode);
            Console.WriteLine("Batch: " + ucpc.BatchCode);
        }

        [TestMethod]
        public void UCPCPartialCodeTest()
        {
            //ARRANGE
            var ucpc = new UCPC("CYGU94JYKYUY9V7TAFL200000", PrimaryObjectType.Strain);

            //ACT


            //ASSERT
        }
    }
}
