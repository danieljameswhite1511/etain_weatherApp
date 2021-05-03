using System.Threading.Tasks;
using Infrastructure.Data.RequestHandlers;
using System.Collections.Generic;
using API.Dtos.MetaWeatherApi;

namespace API.ExternalRepositories
{
    public class MetaWeatherRepository : IMetaWeatherRepository
    {
        private readonly string ApiUrl = "https://www.metaweather.com/api/";
        public readonly string ImageUrl = "https://www.metaweather.com/static/img/weather/png/";
        private readonly IHttpEnpointRequest _httpEnpointRequest;

        public MetaWeatherRepository(IHttpEnpointRequest httpEnpointRequest)
        {
            _httpEnpointRequest = httpEnpointRequest;
        }

        public async Task<List<LocationSearchResultDto>> LocationSearchByQuery(string query)
        {

            var routeParams = "location/search/?query=" + query;
            var url = ApiUrl + routeParams;

            var result = await _httpEnpointRequest.Get<List<LocationSearchResultDto>>(url);

            return result;
        }

        public async Task<List<LocationSearchResultDto>> LocationSearchByLatLong(string latitude, string longitude)
        {

            var routeParams = "location/search/?lattlong=" + latitude + "," + longitude;
            var url = ApiUrl + routeParams;

            var result = await _httpEnpointRequest.Get<List<LocationSearchResultDto>>(url);

            return result;
        }

        public async Task<WeatherSummaryDto> LocationSearchByWoeId(int woeId)
        {

            var routeParams = "location/" + woeId + "/";
            var url = ApiUrl + routeParams;

            var result = await _httpEnpointRequest.Get<WeatherSummaryDto>(url);

            return result;
        }

        public async Task<List<WeatherDto>> LocationSearchByWoeIdAndDate(int woeId, string year, string month, string day)
        {

            var routeParams = "location/" + woeId + "/" + year + "/" + month + "/" + day;
            var url = ApiUrl + routeParams;

            var result = await _httpEnpointRequest.Get<List<WeatherDto>>(url);


            return result;
        }
    }
}