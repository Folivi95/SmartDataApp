using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using SmartDataApp.Models;
using SmartDataApp.Models.DTOs;

namespace SmartDataApp.Interfaces
{
    public interface IElasticSearchService
    {
        Task<PagedResponse<List<PropertiesDto>>> GetPropertiesData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, string controllerName, IUrlHelper urlHelper, int limit = 25);
        Task<PagedResponse<List<MgmtDto>>> GetMgmtData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, string controllerName, IUrlHelper urlHelper, int limit = 25 );
    }
}