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
    public class ProductQA
    {
        [TestMethod]
        public void ProductModelTest()
        {
            //ARRANGE
            string json = null;
            string path = "JSON/Product/Products.json";
            var products = new List<Product>();


            //ACT
            Debug.WriteLine("Path: " + path);

            using (var reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            JObject rawData = JObject.Parse(json);

            //Debug.WriteLine(rawData["data"].ToString());

            foreach (JToken product in rawData["data"].Children())
            {
                Product tempProduct = product.ToObject<Product>();
                Console.WriteLine("Product Added: " + tempProduct.Name);
                products.Add(tempProduct);
            }

            //ASSERT
            Assert.IsNotNull(json);
            Assert.IsTrue(json != "");
            Assert.IsTrue(products.Count > 0); //*/

            foreach (Product product in products)
            {
                Assert.IsTrue(product.IsValid());
            }

            //OUTPUT
            Console.WriteLine("Product Count: " + products.Count);

        }

        [TestMethod]
        public void ProductRequestTest()
        {
            //ARRANGE
            var products = new List<Product>();

            //ACT
            products = (List<Product>)ProductController.GetProducts();

            //ASSERT
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);

            //OUTPUT
            foreach (Product product in products)
            {
                Console.WriteLine("Product: " + product.Name);
            }

            Console.WriteLine("Product Count: " + products.Count);
        }

        [TestMethod]
        public void ProductByTypeTest()
        {
            //ARRANGE
            var products = new List<Product>();

            //ACT
            products = (List<Product>)ProductController.GetProductByType(SecondaryObjectType.PreRoll);

            //ASSERT
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);

            //OUTPUT
            foreach (Product product in products)
            {
                Console.WriteLine("Product: " + product.Name);
                Console.WriteLine("THC: " + product.THC);
                Console.WriteLine("CBD: " + product.CBD);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Product Count: " + products.Count);
        }

        [TestMethod]
        public void SingleProductRequestTest()
        {
            //ARRANGE
            var product = new Product();

            //ACT
            product = ProductController.GetProduct("9XVU7NK3PEGLAJ372X4F00000");

            //ASSERT
            Assert.IsNotNull(product);
            Assert.IsTrue(product.IsValid());
            Assert.IsTrue(product.Name == "Cherry Kola - Pre-roll");

            //OUTPUT
            Console.WriteLine("Product: " + product.Name);
        }

        [TestMethod]
        public void ProductUserTest()
        {
            //ARRANGE
            var user = new User();

            //ACT
            user = ProductController.GetProductUser("9XVU7NK3PEGLAJ372X4F00000");

            //ASSERT
            Assert.IsNotNull(user); ;
            Assert.IsTrue(user.IsValid());
            Assert.IsTrue(user.Nickname == "Shelly");

            //OUTPUT
            Console.WriteLine("Name: " + user.Nickname);
        }

        [TestMethod]
        public void ProductReviewsTest()
        {
            //ARRANGE
            var reviews = new List<Review>();

            //ACT
            reviews = (List<Review>)ProductController.GetProductReviews("0000000000C6FZLK664400000", 1);

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
        public void ProductEffectsAndFlavorsTest()
        {
            //ARRANGE
            var effectsAndFlavors = new EffectsAndFlavors();

            //ACT
            effectsAndFlavors = ProductController.GetProductEffectsFlavors("0000000000C6FZLK664400000");

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
        public void ProductProducerTest()
        {
            //ARRANGE
            var producer = new Producer();

            //ACT
            producer = ProductController.GetProductProducer("0000000000C6FZLK664400000");

            //ASSERT
            Assert.IsNotNull(producer);
            Assert.IsTrue(producer.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + producer.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void ProductStrainTest()
        {
            //ARRANGE
            var strain = new Strain();

            //ACT
            strain = ProductController.GetProductStrain("9XVU7NK3PEGLAJ372X4F00000");

            //ASSERT
            Assert.IsNotNull(strain);
            Assert.IsTrue(strain.IsValid());

            //OUTPUT
            Console.WriteLine("Name: " + strain.Name);
            Console.WriteLine("Seed Company: " + strain.SeedCompany.Name);
            Console.WriteLine("------------------------");
        }

        [TestMethod]
        public void ProductAvailabilityTest()
        {
            //ARRANGE
            var menuItemSummaries = new List<MenuItemSummary>();

            //ACT
            menuItemSummaries = (List<MenuItemSummary>)ProductController.GetProductAvailability
                (
                    "9XVU7NK3PEGLAJ372X4F00000",
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
