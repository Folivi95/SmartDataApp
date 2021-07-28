using System.Collections.Generic;
using System.Threading.Tasks;
using SmartDataApp.Models;
using SmartDataApp.Models.DTOs;

namespace SmartDataApp.Interfaces
{
    public interface IElasticSearchService
    {
        Task<PagedResponse<PropertiesDto>> GetPropertiesData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, int limit = 25);
        Task<PagedResponse<MgmtDto>> GetMgmtData(ResourceParameters parameters, string searchPhrase, 
            List<string> market, int limit = 25 );
    }
}