using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDataApp.Interfaces;
using SmartDataApp.Models;

namespace SmartDataApp.Controllers
{
    [Route("api/v1/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IElasticSearchService _elasticSearchService;

        public SearchController(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService ?? throw new ArgumentNullException(nameof(elasticSearchService));
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]string searchPhrase, string market, int limit, ResourceParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}