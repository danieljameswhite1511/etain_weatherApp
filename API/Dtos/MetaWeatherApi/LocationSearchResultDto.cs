
namespace API.Dtos.MetaWeatherApi
{
    public class LocationSearchResultDto
    {
        public string Title { get; set; }
        public string Location_Type { get; set; }
        public int WoeId { get; set; }
        public string LatLong { get; set; }
        public string TimeZone { get; set; }
    }
}