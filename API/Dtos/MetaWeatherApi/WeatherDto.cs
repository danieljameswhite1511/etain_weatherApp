using System;

namespace API.Dtos.MetaWeatherApi
{
    public class WeatherDto
    {
     // public long id { get; set; }
      private string imageUrl = "https://www.metaweather.com/static/img/weather/png/";
      public string weather_state_image_url { get{ return imageUrl + weather_state_abbr + ".png";} }
      
      public string weather_state_name { get; set; }
      public string weather_state_abbr { get; set; }

      public string wind_direction_compass { get; set; }
      public DateTime? created { get; set; }
      public DateTime? applicable_date { get; set; }
      public decimal? min_temp { get; set; }
      public decimal? max_temp { get; set; }
      public decimal? the_temp { get; set; }
      public decimal? wind_speed { get; set; }
      public decimal? wind_direction { get; set; }
      public decimal? air_pressure { get; set; }
      public int? humidity { get; set; }
      public decimal? visibility { get; set; }
      public int? predictability { get; set; }
    }
}