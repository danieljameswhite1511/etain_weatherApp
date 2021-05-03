using System.Linq;
using API.Dtos;
using API.Dtos.MetaWeatherApi;
using AutoMapper;
using Core.Entities;
using Core.Identity.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
       
            CreateMap<Address, AddressDto>().ReverseMap();

            //Menus
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<Menu, MenuDto>()
            .ForMember(dest => dest.MenuItems, opt => opt.MapFrom(src => src.MenuItems.Where(x => x.ParentId == null)));

            //Weather
            CreateMap<Weather, WeatherDto>()
            //.ForMember(x=>x.id, opt=>opt.MapFrom(x=>x.ExternalSystemId))
            .ForMember(x=>x.weather_state_image_url, opt=>opt.MapFrom(x=>x.WeatherStateImageUrl))
            .ForMember(x=>x.weather_state_name, opt=>opt.MapFrom(x=>x.WeatherStateName))
            .ForMember(x=>x.weather_state_abbr, opt=>opt.MapFrom(x=>x.WeatherStateAbbr))
            .ForMember(x=>x.wind_direction_compass, opt=>opt.MapFrom(x=>x.WindDirectionCompass))
            .ForMember(x=>x.created, opt=>opt.MapFrom(x=>x.Created))
            .ForMember(x=>x.applicable_date, opt=>opt.MapFrom(x=>x.ApplicableDate))
            .ForMember(x=>x.min_temp, opt=>opt.MapFrom(x=>x.MinTemp))
            .ForMember(x=>x.max_temp, opt=>opt.MapFrom(x=>x.MaxTemp))
            .ForMember(x=>x.the_temp, opt=>opt.MapFrom(x=>x.TheTemp))
            .ForMember(x=>x.wind_speed, opt=>opt.MapFrom(x=>x.WindSpeed))
            .ForMember(x=>x.wind_direction, opt=>opt.MapFrom(x=>x.WindDirection))
            .ForMember(x=>x.air_pressure, opt=>opt.MapFrom(x=>x.AirPressure))
            .ForMember(x=>x.humidity, opt=>opt.MapFrom(x=>x.Humidity))
            .ForMember(x=>x.visibility, opt=>opt.MapFrom(x=>x.Visibility))
            .ForMember(x=>x.predictability, opt=>opt.MapFrom(x=>x.Predictability)).ReverseMap();
            

            CreateMap<WeatherSummary, WeatherSummaryDto>()
            .ForMember(x=>x.Title, opt=>opt.MapFrom(x=>x.Title))
            .ForMember(x=>x.Location_Type, opt=>opt.MapFrom(x=>x.LocationType))
            .ForMember(x=>x.WoeId, opt=>opt.MapFrom(x=>x.WoeId))
            .ForMember(x=>x.LatLong, opt=>opt.MapFrom(x=>x.LatitudeLongitude))
            .ForMember(x=>x.Time_Zone, opt=>opt.MapFrom(x=>x.TimeZone))
            .ForMember(x=>x.Time, opt=>opt.MapFrom(x=>x.Time))
            .ForMember(x=>x.Sun_Rise, opt=>opt.MapFrom(x=>x.SunRise))
            .ForMember(x=>x.Sun_Set, opt=>opt.MapFrom(x=>x.SunSet))
            .ForMember(x=>x.Consolidated_Weather, opt=>opt.MapFrom(x=>x.ConsolidatedWeather))
            .ForMember(x=>x.Parent, opt=>opt.MapFrom(x=>x.Parent))
            .ForMember(x=>x.Sources, opt=>opt.MapFrom(x=>x.Sources)).ReverseMap();
            
            CreateMap<LocationSearchResult, LocationSearchResultDto>()
            .ForMember(x=>x.Title, opt=>opt.MapFrom(x=>x.Title))
            .ForMember(x=>x.Location_Type, opt=>opt.MapFrom(x=>x.LocationType))
            .ForMember(x=>x.WoeId, opt=>opt.MapFrom(x=>x.WoeId))
            .ForMember(x=>x.LatLong, opt=>opt.MapFrom(x=>x.LatLong))
            .ForMember(x=>x.TimeZone, opt=>opt.MapFrom(x=>x.TimeZone)).ReverseMap();
            
            CreateMap<Source, SourceDto>()
            .ForMember(x=>x.Title, opt=>opt.MapFrom(x=>x.Title))
            .ForMember(x=>x.Slug, opt=>opt.MapFrom(x=>x.Slug))
            .ForMember(x=>x.Url, opt=>opt.MapFrom(x=>x.Url))
            .ForMember(x=>x.Crawl_Rate, opt=>opt.MapFrom(x=>x.CrawlRate)).ReverseMap();

        }
    }
}