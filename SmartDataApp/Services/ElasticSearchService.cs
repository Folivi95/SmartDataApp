using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
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
            string uriString = Environment.GetEnvironmentVariable("ELK_URL");
            string userName = Environment.GetEnvironmentVariable("ELK_USERNAME");
            string password = Environment.GetEnvironmentVariable("ELK_PASSWORD");
             var connectionSettings = new ConnectionSettings(new Uri(uriString!))
                 .BasicAuthentication(userName, password)
                 .DefaultIndex("mgmt")
                 .DefaultMappingFor<PropertiesDto>(i => 
                     i.IndexName("properties"))
                 .DefaultMappingFor<MgmtDto>(i =>
                     i.IndexName("mgmt"))
                 .EnableDebugMode()
                 .PrettyJson()
                 .RequestTimeout(TimeSpan.FromMinutes(2));

            _client = new ElasticClient(connectionSettings);

            // var settings = new ConnectionConfiguration(new Uri(uriString!))
            //     .BasicAuthentication(userName, password)
            //     .RequestTimeout(TimeSpan.FromMinutes(2));
            //
            // _client = new ElasticLowLevelClient(settings);
        }

        public async Task<PagedResponse<List<PropertiesDto>>> GetPropertiesData(
            ResourceParameters parameters, string searchPhrase,
            List<string> market, string controllerName, IUrlHelper urlHelper, int limit = 25)
        {
            List<string> searchItems = searchPhrase.ContainsKeywords();

            var searchResponse = await _client.SearchAsync<PropertiesDto>(p => p
                .Query(q =>
                    q.Bool(b => 
                        b.Should(
                            bs => bs.MatchAny("name", searchItems),
                            bs => bs.MatchAny("market", market)))
                )
                .Size(limit)
            );

            var queryData = searchResponse.Documents.ToList();
            var pagedData = await PagedList<PropertiesDto>.Create(queryData,
                parameters.PageNumber, parameters.PageSize);

            var paginationData = PageUtility<PropertiesDto>
                .CreateResourcePageUrl(parameters, controllerName, pagedData, urlHelper);

            var meta = new Meta()
            {
                pagination = paginationData
            };

            var response = new PagedResponse<List<PropertiesDto>>
            {
                success = true,
                message = "Properties data retrieved successfully",
                data = pagedData,
                meta = meta
            };

            return response;
        }

        public async Task<PagedResponse<List<MgmtDto>>> GetMgmtData(ResourceParameters parameters,
            string searchPhrase,
            List<string> market, string controllerName, IUrlHelper urlHelper, int limit = 25)
        {
            List<string> searchItems = searchPhrase.ContainsKeywords();

            var searchResponse = await _client.SearchAsync<MgmtDto>(p => p
                .Query(q =>
                    q.MatchAny("name", searchItems) ||
                    q.MatchAny("market", market)
                )
                .Size(limit)
            );

            var queryData = searchResponse.Documents.ToList();
            var pagedData = await PagedList<MgmtDto>.Create(queryData,
                parameters.PageNumber, parameters.PageSize);

            var paginationData = PageUtility<MgmtDto>
                .CreateResourcePageUrl(parameters, controllerName, pagedData, urlHelper);

            var meta = new Meta()
            {
                pagination = paginationData
            };

            var response = new PagedResponse<List<MgmtDto>>()
            {
                success = true,
                message = "Properties data retrieved successfully",
                data = pagedData,
                meta = meta
            };

            return response;
        }
    }
}