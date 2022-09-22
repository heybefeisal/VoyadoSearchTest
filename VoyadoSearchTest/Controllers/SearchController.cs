using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoyadoSearchTest.Services;
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

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get(int id)
        {
            var words = SearchResults(id).ToList();  
            if(!words.Any())
            {
                return NoContent();
            }
            return Ok(words);
            /*return words*/;
            //return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public double Post([FromForm] string searchText)
        {
            string[] searchArr = searchText.Split(" ");

            SearchResultService search = new SearchResultService();

            search.SearchResults(searchArr);

            return search.TotalCount;
        }


    }
}
