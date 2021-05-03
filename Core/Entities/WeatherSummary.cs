using System;
using System.Collections.Generic;
using Core.Identity.Entities;

namespace Core.Entities
{
    public class WeatherSummary : BaseEntity
    {
        public string IpAddress { get; set; }
        public int? UserSearchId { get; set; }
        public UserSearch UserSearch { get; set; }
        public string Title { get; set; }
        public string LocationType { get; set; }
        public int WoeId { get; set; }
        public string LatitudeLongitude { get; set; }
        public string TimeZone { get; set; }
        public string Time { get; set; }
        public string  SunRise { get; set; }
        public string SunSet  { get; set; }
        public List<Weather> ConsolidatedWeather { get; set; }
        public LocationSearchResult Parent { get; set; }

        public List<Source> Sources { get; set; }



        
    }
}