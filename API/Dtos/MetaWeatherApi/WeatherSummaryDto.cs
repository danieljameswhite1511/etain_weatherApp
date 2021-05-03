using System.Collections.Generic;

namespace API.Dtos.MetaWeatherApi
{
    public class WeatherSummaryDto
    {
        public string IpAddress { get; set; }
        public string Title { get; set; }
        public string Location_Type { get; set; }
        public int WoeId { get; set; }
        public string LatLong { get; set; }
        public string Time_Zone { get; set; }
        public string Time { get; set; }
        public string  Sun_Rise { get; set; }
        public string Sun_Set  { get; set; }
        public List<WeatherDto> Consolidated_Weather { get; set; }
        public LocationSearchResultDto Parent { get; set; }
        public List<SourceDto> Sources { get; set; }
    }
}