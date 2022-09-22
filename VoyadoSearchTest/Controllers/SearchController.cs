using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyadoSearchTest.Services.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VoyadoSearchTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchResultService _searchResultService;
        public SearchController(ISearchResultService searchResultService)
        {
            _searchResultService = searchResultService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get([FromQuery] string[] searchWord)
        {
            var result = _searchResultService.SearchWord(searchWord);

            return Ok(result);
        }

    }
}
