using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class StrainController
    {
        public static IEnumerable<Strain> GetStrains(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Strain);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Strain> strains = DataRequester.GetObjects<Strain>(urlGenerator.URL);

            return strains;
        }

        public static Strain GetStrain(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Strain strain = DataRequester.GetObject<Strain>(urlGenerator.URL);

            return strain;
        }

        public static IEnumerable<Strain> LookupStrain(string query)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Strain, query);

            IEnumerable<Strain> strains = DataRequester.GetObjects<Strain>(urlGenerator.URL);

            return strains;
        }

        public static User GetStrainUser(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject,SecondaryObjectType.User);

            User user = DataRequester.GetObject<User>(urlGenerator.URL);

            return user;
        }

        public static IEnumerable<Review> GetStrainReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject,SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);
            
            return reviews;
        }

        public static EffectsAndFlavors GetStrainEffectsFlavors(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.EffectsAndFlavors);

            EffectsAndFlavors effectsAndFlavors = DataRequester.GetObject<EffectsAndFlavors>(urlGenerator.URL);

            return effectsAndFlavors;
        }

        public static SeedCompany GetStrainSeedCompany(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.SeedCompany);

            SeedCompany seedCompany = DataRequester.GetObject<SeedCompany>(urlGenerator.URL);

            return seedCompany;
        }

        public static IEnumerable<Strain> GetStrainGenetics(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Genetics);

            IEnumerable<Strain> strains = DataRequester.GetObjects<Strain>(urlGenerator.URL);

            return strains;
        }

        public static IEnumerable<Strain> GetStrainChildren(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Children);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Strain> strains = DataRequester.GetObjects<Strain>(urlGenerator.URL);

            return strains;
        }

        public static IEnumerable<MenuItemSummary> GetStrainAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Strain);

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
