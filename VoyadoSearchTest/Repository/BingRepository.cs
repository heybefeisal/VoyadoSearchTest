using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoyadoSearchTest.Repository.Interfaces;

namespace VoyadoSearchTest.Repository
{
    public class BingRepository : IBingRepository
    {
        public BingRepository(IOptions<AppSettings> options)
        {
            BingUrl = options.Value.BingUrl;
            BingApiKey = options.Value.BingApiKey;
        }

        public static string BingUrl { get; set; }
        public static string BingApiKey { get; set; }


        public int SearchBing(string[] words) // messi xavi
        {
            var client = new RestClient(BingUrl); // Initierar kontakt mot bing api:et
            int totalCount = 0; // Resultatet av antal träff varje ord fick

            string resource = "/v7.0/search?q="; // Full Url blir https://api.bing.microsoft.com/v7.0/search?q=word

            foreach (var word in words)
            {
                resource += word;
                var request = new RestRequest(resource, Method.GET);
                request.AddHeader("Ocp-Apim-Subscription-Key", BingApiKey); // Ett obligatorisk fält som måste finnas med i Bings Api.

                var response = client.Execute<dynamic>(request);

                var wordCount = response.Data["webPages"]["totalEstimatedMatches"]; // Fiskar ut relevant properties, totalEstimatedMatches är antal träff ordet fick.

                totalCount += wordCount; // Plussar på totaltCount för varje ord i arrayen
            }

            return totalCount;
        }
    }
}
