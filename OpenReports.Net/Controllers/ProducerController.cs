using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class ProducerController
    {
        public static IEnumerable<Producer> GetProducers(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Producer);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Producer> producers = DataRequester.GetObjects<Producer>(urlGenerator.URL);

            return producers;
        }

        public static Producer GetProducer(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Producer);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Producer producer = DataRequester.GetObject<Producer>(urlGenerator.URL);

            return producer;
        }

        public static IEnumerable<Extract> GetProducerExtracts(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Producer);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject,SecondaryObjectType.Extract);

            IEnumerable<Extract> extracts = DataRequester.GetObjects<Extract>(urlGenerator.URL);

            return extracts;
        }

        public static IEnumerable<Edible> GetProducerEdibles(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Producer);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Edible);

            IEnumerable<Edible> edibles = DataRequester.GetObjects<Edible>(urlGenerator.URL);

            return edibles;
        }

        public static IEnumerable<Product> GetProducerProducts(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Producer);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Product);

            IEnumerable<Product> products = DataRequester.GetObjects<Product>(urlGenerator.URL);

            return products;
        }

        public static IEnumerable<MenuItemSummary> GetProducerAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Producer);

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
