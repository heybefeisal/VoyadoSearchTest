using VoyadoSearchTest.Repository.Interfaces;
using VoyadoSearchTest.Services.Interfaces;

namespace VoyadoSearchTest.Services
{
    public class SearchResultService : ISearchResultService
    {
        private readonly IBingRepository bingRepository;
        public SearchResultService(IBingRepository bingRepository)
        {
            this.bingRepository = bingRepository;
        }

        public int SearchWord(string[] word)
        {
            var result = bingRepository.SearchBing(word);

            return result;
        }

    }
}
