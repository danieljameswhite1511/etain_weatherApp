using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.MetaWeatherApi;

namespace API.ExternalRepositories
{
     public interface IMetaWeatherRepository
    {
        Task<List<LocationSearchResultDto>> LocationSearchByLatLong(string latitude, string longitude);
        Task<List<LocationSearchResultDto>> LocationSearchByQuery(string query);
        Task<WeatherSummaryDto> LocationSearchByWoeId(int woeId);
        Task<List<WeatherDto>> LocationSearchByWoeIdAndDate(int woeId, string year, string month, string day);
    }
}