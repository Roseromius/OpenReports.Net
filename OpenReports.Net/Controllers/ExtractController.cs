using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    class ExtractController
    {
        public static IEnumerable<Extract> GetFlowers(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Flower);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Extract> flowers = DataRequester.GetObjects<Extract>(urlGenerator.URL);

            return flowers;
        }

        public static IEnumerable<Flower> GetFlowerByType(SecondaryObjectType type, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Flower, type);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);

            IEnumerable<Flower> flowers = DataRequester.GetObjects<Flower>(urlGenerator.URL);

            return flowers;
        }

        public static Flower GetFlower(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Flower flower = DataRequester.GetObject<Flower>(urlGenerator.URL);

            return flower;
        }

        public static User GetFlowerUser(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.User);

            User user = DataRequester.GetObject<User>(urlGenerator.URL);

            return user;
        }

        public static IEnumerable<Review> GetFlowerReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);

            return reviews;
        }

        public static EffectsAndFlavors GetFlowerEffectsFlavors(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.EffectsAndFlavors);

            EffectsAndFlavors effectsAndFlavors = DataRequester.GetObject<EffectsAndFlavors>(urlGenerator.URL);

            return effectsAndFlavors;
        }

        public static Producer GetFlowerProducer(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Producer);

            Producer producer = DataRequester.GetObject<Producer>(urlGenerator.URL);

            return producer;
        }

        public static Strain GetFlowerStrain(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Strain);


            Strain strain = DataRequester.GetObject<Strain>(urlGenerator.URL);

            return strain;
        }

        public static IEnumerable<MenuItemSummary> GetFlowerAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Flower);

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
