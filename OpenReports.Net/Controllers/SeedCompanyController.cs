using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class SeedCompanyController
    {
        public static SeedCompany GetSeedCompany(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.SeedCompany);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            SeedCompany seedCompany = DataRequester.GetObject<SeedCompany>(urlGenerator.URL);

            return seedCompany;
        }

        public static IEnumerable<Strain> GetSeedCompanyStrains(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.SeedCompany);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Strain, isPlural: true);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Strain> reviews = DataRequester.GetObjects<Strain>(urlGenerator.URL);

            return reviews;
        }

        public static IEnumerable<Review> GetSeedCompanyReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.SeedCompany);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);

            return reviews;
        }

    }
}
