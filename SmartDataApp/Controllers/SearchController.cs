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

        [HttpGet("properties", Name = "GetProperties")]
        public async Task<IActionResult> GetProperties([FromQuery]string searchPhrase,[FromQuery] List<string> market, 
           [FromQuery] int limit, [FromQuery] ResourceParameters parameters)
        {
            try
            {
                if (limit == 0)
                {
                    limit = 25;
                }
                
                var response = await _elasticSearchService.GetPropertiesData(parameters, searchPhrase, market, 
                    nameof(GetProperties), Url, limit);

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, Response<string>.InternalError(e.Message));
            }
        }
        
        [HttpGet("mgmt", Name = "GetMgmt")]
        public async Task<IActionResult> GetMgmt([FromQuery]string searchPhrase, [FromQuery] List<string> market, 
            [FromQuery] int limit, [FromQuery] ResourceParameters parameters)
        {
            try
            {
                if (limit == 0)
                {
                    limit = 25;
                }
                
                var response = await _elasticSearchService.GetMgmtData(parameters, searchPhrase, market, 
                    nameof(GetMgmt), Url, limit);

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, Response<string>.InternalError(e.Message));
            }
        }
    }
}