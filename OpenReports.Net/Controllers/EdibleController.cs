using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class EdibleController
    {
        public static IEnumerable<Edible> GetEdibles(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Edible);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Edible> edibles = DataRequester.GetObjects<Edible>(urlGenerator.URL);

            return edibles;
        }

        public static IEnumerable<Edible> GetEdibleByType(SecondaryObjectType type, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Edible, type);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);

            IEnumerable<Edible> edibles = DataRequester.GetObjects<Edible>(urlGenerator.URL);

            return edibles;
        }

        public static Edible GetEdible(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Edible edible = DataRequester.GetObject<Edible>(urlGenerator.URL);

            return edible;
        }

        public static User GetEdibleUser(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.User);

            User user = DataRequester.GetObject<User>(urlGenerator.URL);

            return user;
        }

        public static IEnumerable<Review> GetEdibleReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);

            return reviews;
        }

        public static EffectsAndFlavors GetEdibleEffectsFlavors(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.EffectsAndFlavors);

            EffectsAndFlavors effectsAndFlavors = DataRequester.GetObject<EffectsAndFlavors>(urlGenerator.URL);

            return effectsAndFlavors;
        }

        public static Producer GetEdibleProducer(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Producer);

            Producer producer = DataRequester.GetObject<Producer>(urlGenerator.URL);

            return producer;
        }

        public static Strain GetEdibleStrain(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Strain);

            Strain strain = DataRequester.GetObject<Strain>(urlGenerator.URL);

            return strain;
        }

        public static IEnumerable<MenuItemSummary> GetEdibleAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Edible);

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
