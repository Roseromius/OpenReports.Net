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
            string pageArguement = "page=" + pageNumber;
            string sortArguement = "sort=" + UrlGenerator.SortEnumToString(sortingOption);
            string url = "https://www.cannabisreports.com/api/v1.0/strains";
            var strains = new List<Strain>();

            if(sortingOption != SortOption.Unassigned)
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
                url = url + pageArguement;
            }

            string json = DataRequester.GetData(url);

            JObject rawData = JObject.Parse(json);

            foreach (JToken strain in rawData["data"].Children())
            {
                Strain tempStrain = strain.ToObject<Strain>();
                strains.Add(tempStrain);
            }

            return strains;
        }

        public static Strain GetStrain(string ucpc)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc;

            string json = DataRequester.GetData(url);

            JObject rawData = JObject.Parse(json);

            Strain strain = rawData["data"].ToObject<Strain>();

            return strain;
        }

        public static IEnumerable<Strain> LookupStrain(string text)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/search/" + text;
            string json = DataRequester.GetData(url);
            var strains = new List<Strain>();

            JObject rawData = JObject.Parse(json);

            foreach (JToken strain in rawData["data"].Children())
            {
                Strain tempStrain = strain.ToObject<Strain>();
                strains.Add(tempStrain);
            }

            return strains;
        }

        public static User GetStrainUser(string ucpc)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/user";
            string json = DataRequester.GetData(url);

            JObject rawData = JObject.Parse(json);
            User user = rawData["data"].ToObject<User>();

            return user;
        }

        public static IEnumerable<Review> GetStrainReviews(string ucpc, int pageNumber = 0)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/reviews";
            string pageArguement = "?page=" + pageNumber;
            string json = DataRequester.GetData(url);
            var reviews = new List<Review>();

            JObject rawData = JObject.Parse(json);

            if (pageNumber > 0)
            {
                url = url + pageArguement;
            }

            foreach (JToken token in rawData["data"].Children())
            {
                Review review = token.ToObject<Review>();
                reviews.Add(review);
            }
            
            return reviews;
        }

        public static EffectsAndFlavors GetStrainEffectsFlavors(string ucpc)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/effectsFlavors";

            string json = DataRequester.GetData(url);

            JObject rawData = JObject.Parse(json);

            EffectsAndFlavors effectsAndFlavors = rawData["data"].ToObject<EffectsAndFlavors>();

            return effectsAndFlavors;
        }

        public static SeedCompany GetStrainSeedCompany(string ucpc)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/seedCompany";

            string json = DataRequester.GetData(url);

            JObject rawData = JObject.Parse(json);

            SeedCompany seedCompany = rawData["data"].ToObject<SeedCompany>();

            return seedCompany;
        }

        public static IEnumerable<Strain> GetStrainGenetics(string ucpc)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/genetics";
            string json = DataRequester.GetData(url);
            var strains = new List<Strain>();

            JObject rawData = JObject.Parse(json);

            foreach (JToken strain in rawData["data"].Children())
            {
                Strain tempStrain = strain.ToObject<Strain>();
                strains.Add(tempStrain);
            }

            return strains;
        }

        public static IEnumerable<Strain> GetStrainChildren(string ucpc, int pageNumber = 0)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc + "/children";
            string pageArguement = "?page=" + pageNumber;
            string json = DataRequester.GetData(url);
            var strains = new List<Strain>();

            JObject rawData = JObject.Parse(json);

            if (pageNumber > 0)
            {
                url = url + pageArguement;
            }

            foreach (JToken strain in rawData["data"].Children())
            {
                Strain tempStrain = strain.ToObject<Strain>();
                strains.Add(tempStrain);
            }

            return strains;
        }

        public static IEnumerable<MenuItemSummary> GetStrainAvailability(string ucpc, decimal latitude, decimal longitude, int radiusInMiles, int pageNumber = 0)
        {
            string url = "https://www.cannabisreports.com/api/v1.0/strains/" + ucpc
                + "/availability/geo/" + latitude + "/" + longitude;
            string pageArguement = "?page=" + pageNumber;
            string json = DataRequester.GetData(url);
            var menuItemSummaries = new List<MenuItemSummary>();

            JObject rawData = JObject.Parse(json);

            if (radiusInMiles > 0)
            {
                url = url + "/" + radiusInMiles.ToString();
            }

            if (pageNumber > 0)
            {
                url = url + pageArguement;
            }

            foreach (JToken menuItemSummary in rawData["data"].Children())
            {
                MenuItemSummary tempSummary = menuItemSummary.ToObject<MenuItemSummary>();
                menuItemSummaries.Add(tempSummary);
            }

            return menuItemSummaries;
        }
    }
}
