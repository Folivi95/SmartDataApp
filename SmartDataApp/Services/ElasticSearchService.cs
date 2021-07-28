using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Nest;
using SmartDataApp.Helpers;
using SmartDataApp.Interfaces;
using SmartDataApp.Models;
using SmartDataApp.Models.DTOs;

namespace SmartDataApp.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;

        public ElasticSearchService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            var connectionSettings = new ConnectionSettings()
                .BasicAuthentication(Environment.GetEnvironmentVariable("ELK_USERNAME"),
                    Environment.GetEnvironmentVariable("ELK_PASSWORD"))
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));

            _client = new ElasticClient(connectionSettings);
        }

        public async Task<PagedResponse<PropertiesDto>> GetPropertiesData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, int limit = 25)
        {
            try
            {
                List<string> searchItems = searchPhrase.ContainsKeywords();

                var searchResponse = await _client.SearchAsync<PropertiesDto>(p => p
                    .Query(q =>
                        q.MatchAny("name", searchItems) ||
                        q.MatchAny("market", market)
                    )
                    .Size(limit)
                );

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<PagedResponse<MgmtDto>> GetMgmtData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, int limit = 25)
        {
            try
            {
                // checck search phrase for keywords
                List<string> searchItems = searchPhrase.ContainsKeywords();

                var searchResponse = await _client.SearchAsync<PropertiesDto>(p => p
                    .Query(q =>
                        q.MatchAny("name", searchItems) ||
                        q.MatchAny("market", market)
                    )
                    .Size(limit)
                );

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}