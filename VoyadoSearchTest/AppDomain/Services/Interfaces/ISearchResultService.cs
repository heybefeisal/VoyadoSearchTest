using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoyadoSearchTest.Services.Interfaces
{
    public interface ISearchResultService
    {
        void SearchResults(string[] words);

        void SearchBingResult(string word);

    }
}
