﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class ExtractController
    {
        public static IEnumerable<Extract> GetExtracts(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Extract);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);//ADD SORTING/PAGE OPTIONS

            IEnumerable<Extract> extracts = DataRequester.GetObjects<Extract>(urlGenerator.URL);

            return extracts;
        }

        public static IEnumerable<Extract> GetExtractByType(SecondaryObjectType type, int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            var urlGenerator = new UrlGenerator();

            urlGenerator.GenerateCannabisReportsUrl(PrimaryObjectType.Extract, type);

            urlGenerator.AddQueryParameters(pageNumber, sortingOption);

            IEnumerable<Extract> extracts = DataRequester.GetObjects<Extract>(urlGenerator.URL);

            return extracts;
        }

        public static Extract GetExtract(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject);

            Extract extract = DataRequester.GetObject<Extract>(urlGenerator.URL);

            return extract;
        }

        public static User GetExtractUser(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.User);

            User user = DataRequester.GetObject<User>(urlGenerator.URL);

            return user;
        }

        public static IEnumerable<Review> GetExtractReviews(string ucpc, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Review);
            urlGenerator.AddQueryParameters(pageNumber);

            IEnumerable<Review> reviews = DataRequester.GetObjects<Review>(urlGenerator.URL);

            return reviews;
        }

        public static EffectsAndFlavors GetExtractEffectsFlavors(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.EffectsAndFlavors);

            EffectsAndFlavors effectsAndFlavors = DataRequester.GetObject<EffectsAndFlavors>(urlGenerator.URL);

            return effectsAndFlavors;
        }

        public static Producer GetExtractProducer(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Producer);

            Producer producer = DataRequester.GetObject<Producer>(urlGenerator.URL);

            return producer;
        }

        public static Strain GetExtractStrain(string ucpc)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

            urlGenerator.GenerateCannabisReportsUrl(ucpcObject, SecondaryObjectType.Strain);

            Strain strain = DataRequester.GetObject<Strain>(urlGenerator.URL);

            return strain;
        }

        public static IEnumerable<MenuItemSummary> GetExtractAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            var urlGenerator = new UrlGenerator();
            var ucpcObject = new UCPC(ucpc, PrimaryObjectType.Extract);

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
