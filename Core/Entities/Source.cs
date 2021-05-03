namespace Core.Entities
{
    public class Source : BaseEntity
    {
        public int? WeatherSummaryId { get; set; }
        public WeatherSummary WeatherSummary { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; } 
        public string  Url { get; set; }
        public string CrawlRate { get; set; }
    }
}