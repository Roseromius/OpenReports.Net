using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class ProductController
    {
        public static IEnumerable<Product> GetProducts(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Product);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Product> products = DataRequester.GetObjects<Product>(urlGenerator.URL);

            return products;
        }

        public static IEnumerable<Product> GetProductByType(SecondaryObjectType type, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Product, type);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);

            IEnumerable<Product> products = DataRequester.GetObjects<Product>(urlGenerator.URL);

            return products;
        }

        public static Product GetProduct(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Product product = DataRequester.GetObject<Product>(urlGenerator.URL);

            return product;
        }

        public static User GetProductUser(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.User);

            User user = DataRequester.GetObject<User>(urlGenerator.URL);

            return user;
        }

        public static IEnumerable<Review> GetProductReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);

            return reviews;
        }

        public static EffectsAndFlavors GetProductEffectsFlavors(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.EffectsAndFlavors);

            EffectsAndFlavors effectsAndFlavors = DataRequester.GetObject<EffectsAndFlavors>(urlGenerator.URL);

            return effectsAndFlavors;
        }

        public static Producer GetProductProducer(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Producer);

            Producer producer = DataRequester.GetObject<Producer>(urlGenerator.URL);

            return producer;
        }

        public static Strain GetProductStrain(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Strain);

            Strain strain = DataRequester.GetObject<Strain>(urlGenerator.URL);

            return strain;
        }

        public static IEnumerable<MenuItemSummary> GetProductAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Product);

            urlGenerator.GenerateCannabisReportsUrl
                (
                    ucpcObject,
                    latitude,
                    longitude,
                    radiusInMiles
                );
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<MenuItemSummary> menuItemSummaries = DataRequester.GetObjects<MenuItemSummary>(urlGenerator.URL);

            return menuItemSummaries;
        }

    }
}
