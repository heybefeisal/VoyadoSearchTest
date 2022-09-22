using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VoyadoSearchTest.Services.Interfaces;

namespace VoyadoSearchTest.Services
{
    public class SearchResultService : ISearchResultService
    {
        public double TotalCount { get; set; }
        static string bing_Key = Environment.GetEnvironmentVariable("BING_KEY");
        static string bing_Endpoint = Environment.GetEnvironmentVariable("BING_ENDPOINT") + "/v7.0/search";
        private void SearchBingResult(string word)
        {
            var uriQuery = bing_Endpoint + "?=" + Uri.EscapeDataString(word);

            WebRequest webRequest = HttpWebRequest.Create(uriQuery);
            webRequest.Headers["Ocp-Apim-Subscription-Key"] = bing_Key;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponseAsync().Result;
            string json = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            var pages = parsedJson.pages;

            TotalCount = TotalCount + double.Parse((pages.totalMatches).ToString());
        }


        public void SearchResults(string[] words)
        {
            TotalCount = 0;

            //Calls bing search engine with choosen words in an array
            foreach (string word in words)
            {
                SearchBingResult(word);
            }

        }

        
    }
}
