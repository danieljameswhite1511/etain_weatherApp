namespace Core.Entities
{
    public class LocationSearchResult : BaseEntity
    {
        public int? WeatherSummaryId { get; set; }
        public WeatherSummary WeatherSummary { get; set; }
        public string Title { get; set; }
        public string LocationType { get; set; }
        public int WoeId { get; set; }
        public string LatLong { get; set; }
        public string TimeZone { get; set; }
    }
}