using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class UrlGenerator
    {
        public string URL { get; private set; }
        private const string Domain = "https://www.cannabisreports.com";
        private const string ApiResource = "api";
        private const string ApiVersion = "v1.0";

        public void GenerateCannabisReportsUrl(PrimaryObjectType type)
        {
            var sb = new StringBuilder();
            sb.Append(GetBaseUrl());
            sb.Append(GetPrimaryObjectTypeString(type));

            URL = sb.ToString();
        }

        public void GenerateCannabisReportsUrl(UCPC ucpc)
        {
            GenerateCannabisReportsUrl(ucpc.Type);

            var sb = new StringBuilder();
            sb.Append(URL);
            sb.Append("/");
            sb.Append(ucpc.Code);

            URL = sb.ToString();
        }

        public void GenerateCannabisReportsUrl(UCPC ucpc, SecondaryObjectType secondaryType)
        {
            GenerateCannabisReportsUrl(ucpc);

            var sb = new StringBuilder();
            sb.Append(URL);
            sb.Append("/");
            sb.Append(GetSecondaryObjectTypeString(secondaryType));

            URL = sb.ToString();
        }

        public void GenerateCannabisReportsUrl(PrimaryObjectType type, string query)
        {
            GenerateCannabisReportsUrl(type);

            var sb = new StringBuilder();
            sb.Append(URL);
            sb.Append("/search/");
            sb.Append(query);

            URL = sb.ToString();
        }

        public void GenerateCannabisReportsUrl(PrimaryObjectType primaryType, SecondaryObjectType secondaryType)
        {
            var sb = new StringBuilder();
            sb.Append(GetBaseUrl());
            sb.Append(GetPrimaryObjectTypeString(primaryType));
            sb.Append("/type/");
            sb.Append(GetSecondaryObjectTypeString(secondaryType));

            URL = sb.ToString();
        }

        public void GenerateCannabisReportsUrl(UCPC ucpc, decimal latitude, decimal longitude, int radiusInMiles)
        {
            var sb = new StringBuilder();
            sb.Append(GetBaseUrl());
            sb.Append(GetPrimaryObjectTypeString(ucpc.Type));
            sb.Append("/");
            sb.Append(ucpc.Code);
            sb.Append("/availability/geo/");
            sb.Append(latitude);
            sb.Append("/");
            sb.Append(longitude);
            sb.Append("/");
            sb.Append(radiusInMiles);

            URL = sb.ToString();
        }

        public void AddQueryParameters(int pageNumber = 0, SortOption sortingOption = SortOption.Unassigned)
        {
            if (!String.IsNullOrEmpty(URL))
            {
                string pageArguement = "page=" + pageNumber;
                string sortArguement = "sort=" + UrlGenerator.SortEnumToString(sortingOption);
                string url = URL;

                if (sortingOption != SortOption.Unassigned)
                {
                    if (pageNumber > 0)
                    {
                        url = url + pageArguement + "&" + sortArguement;
                    }
                    else
                    {
                        url = url + sortArguement;
                    }
                }
                else if (pageNumber > 0)
                {
                    url = url + "?" + pageArguement;
                }

                URL = url;
            }
            else
            {
                throw new Exception("You must generate a URL before you can modify it.");
            }
        }

        private string GetBaseUrl()
        {
            var sb = new StringBuilder();

            sb.Append(Domain);
            sb.Append("/");
            sb.Append(ApiResource);
            sb.Append("/");
            sb.Append(ApiVersion);
            sb.Append("/");

            return sb.ToString();
        }

        private string GetPrimaryObjectTypeString(PrimaryObjectType type, bool isSecondaryType = false)
        {
            switch (type)
            {
                case PrimaryObjectType.Strain:
                    return "strains";
                case PrimaryObjectType.Flower:
                    return "flowers";
                case PrimaryObjectType.Extract:
                    return "extracts";
                case PrimaryObjectType.Edible:
                    return "edibles";
                case PrimaryObjectType.Product:
                    return "products";
                case PrimaryObjectType.Producer:
                    return "producers";
                case PrimaryObjectType.Dispensary:
                    return "dispensaries";
                case PrimaryObjectType.SeedCompany:
                    return "seed-companies";
                default:
                    return "UNKNOWN OBJECT";
            }
        }

        private string GetSecondaryObjectTypeString(SecondaryObjectType type)
        {
            switch (type)
            {
                case SecondaryObjectType.Strain:
                    return "strain";
                case SecondaryObjectType.Flowers:
                    return "flowers";
                case SecondaryObjectType.Extract:
                    return "extracts";
                case SecondaryObjectType.Edible:
                    return "edibles";
                case SecondaryObjectType.Producer:
                    return "producer";
                case SecondaryObjectType.Product:
                    return "products";
                case SecondaryObjectType.SeedCompany:
                    return "seedCompany";
                case SecondaryObjectType.Batch:
                    break;
                case SecondaryObjectType.User:
                    return "user";
                case SecondaryObjectType.Review:
                    return "reviews";
                case SecondaryObjectType.EffectsAndFlavors:
                    return "effectsFlavors";
                case SecondaryObjectType.MenuItemSummary:
                    break;
                case SecondaryObjectType.Genetics:
                    return "genetics";
                case SecondaryObjectType.Children:
                    return "children";
                case SecondaryObjectType.Seeds:
                    return "seeds";
                case SecondaryObjectType.Clones:
                    return "clones";
                case SecondaryObjectType.Shake:
                    return "shake";
                case SecondaryObjectType.Oil:
                    break;
                case SecondaryObjectType.Hash:
                    break;
                case SecondaryObjectType.WaterHash:
                    break;
                case SecondaryObjectType.Kief:
                    return "kief";
                case SecondaryObjectType.Wax:
                    break;
                case SecondaryObjectType.Crumble:
                    break;
                case SecondaryObjectType.Honeycomb:
                    break;
                case SecondaryObjectType.Shatter:
                    return "shatter";
                case SecondaryObjectType.VaporizerDisposable:
                    break;
                case SecondaryObjectType.VaporizerCartridge:
                    break;
                case SecondaryObjectType.BakedGoods:
                    return "baked-good";
                case SecondaryObjectType.Candy:
                    break;
                case SecondaryObjectType.Treat:
                    break;
                case SecondaryObjectType.Chocolate:
                    return "chocolate";
                case SecondaryObjectType.Snack:
                    break;
                case SecondaryObjectType.Beverage:
                    break;
                case SecondaryObjectType.Pill:
                    break;
                case SecondaryObjectType.Tincture:
                    break;
                case SecondaryObjectType.Butter:
                    break;
                case SecondaryObjectType.Honey:
                    break;
                case SecondaryObjectType.BreathStrip:
                    break;
                case SecondaryObjectType.Tea:
                    break;
                case SecondaryObjectType.IceCream:
                    break;
                case SecondaryObjectType.Bath:
                    break;
                case SecondaryObjectType.Topical:
                    break;
                case SecondaryObjectType.SkinCare:
                    break;
                case SecondaryObjectType.PreRoll:
                    return "pre-roll";
                case SecondaryObjectType.LipBalm:
                    break;
                case SecondaryObjectType.MassageOil:
                    break;
                case SecondaryObjectType.PersonalLubricant:
                    break;
                default:
                    return "UNKNOWN OBJECT";
            }

            return null;//REMOVE WHEN THIS METHOD IS COMPLETE
        }

        public static string SortEnumToString(SortOption option)
        {
            switch (option)
            {
                case SortOption.AscendingCreatedAt:
                    return "createdAt";
                case SortOption.DescendingCreatedAt:
                    return "-createdAt";
                case SortOption.AscendingUpdatedAt:
                    return "updatedAt";
                case SortOption.DescendingUpdatedAt:
                    return "-updatedAt";
                case SortOption.AscendingAlphabetical:
                    return "name";
                case SortOption.DescendingAlphabetical:
                    return "-name";
                default:
                    return "";
            }
        }
    }
}
