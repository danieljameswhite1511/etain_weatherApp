using System;

namespace Core.Entities
{
    public class Weather : BaseEntity
    {
      public long ExternalSystemId { get; set; }
      public int? WeatherSummaryId { get; set; }
      public WeatherSummary WeatherSummary { get; set; }
      public string WeatherStateImageUrl {get; set;}
      public string WeatherStateName { get; set; }
      public string WeatherStateAbbr { get; set; }
      public string WindDirectionCompass { get; set; }
      public DateTime? Created { get; set; }
      public DateTime? ApplicableDate { get; set; }
      public decimal? MinTemp { get; set; }
      public decimal? MaxTemp { get; set; }
      public decimal? TheTemp { get; set; }
      public decimal? WindSpeed { get; set; }
      public decimal? WindDirection { get; set; }
      public decimal? AirPressure { get; set; }
      public int? Humidity { get; set; }
      public decimal? Visibility { get; set; }
      public int? Predictability { get; set; }
    }
}