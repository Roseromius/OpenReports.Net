using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class DispensaryController
    {
        public static IEnumerable<Dispensary> GetDispensaries(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Dispensary);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Dispensary> dispensaries = DataRequester.GetObjects<Dispensary>(urlGenerator.URL);

            return dispensaries;
        }

        public static Dispensary GetDispensary(string state, string city, string slug)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(state,city, slug);

            Dispensary dispensary = DataRequester.GetObject<Dispensary>(urlGenerator.URL);

            return dispensary;
        }

        public static IEnumerable<MenuItem> GetDispensaryStrainMenuItems(string state, string city, string slug, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(state, city, slug, PrimaryObjectType.Strain);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<MenuItem> menuItems = DataRequester.GetObjects<MenuItem>(urlGenerator.URL);

            return menuItems;
        }

        public static IEnumerable<MenuItem> GetDispensaryExtractMenuItems(string state, string city, string slug, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(state, city, slug, PrimaryObjectType.Extract);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<MenuItem> menuItems = DataRequester.GetObjects<MenuItem>(urlGenerator.URL);

            return menuItems;
        }

        public static IEnumerable<MenuItem> GetDispensaryEdiblesMenuItems(string state, string city, string slug, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(state, city, slug, PrimaryObjectType.Edible);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<MenuItem> menuItems = DataRequester.GetObjects<MenuItem>(urlGenerator.URL);

            return menuItems;
        }

        public static IEnumerable<MenuItem> GetDispensaryProductMenuItems(string state, string city, string slug, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(state, city, slug, PrimaryObjectType.Product);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<MenuItem> menuItems = DataRequester.GetObjects<MenuItem>(urlGenerator.URL);

            return menuItems;
        }
    }
}
