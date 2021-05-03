using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using API.Dtos.MetaWeatherApi;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.ExternalRepositories;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;

namespace API.Controllers
{
 
 
  public class WeatherController : BaseApiController
  {
    private readonly IMetaWeatherRepository _metaWeatherRepository;
    private readonly IGenericRepository<WeatherSummary> _weatherSummaryRepository;
    private readonly IGenericRepository<Weather> _weatherRepository;
    private readonly IGenericRepository<LocationSearchResult> _locationRepository;
    private readonly IGenericRepository<Source> _sourceRepository;
    private readonly IMapper _mapper;

    public WeatherController(IMetaWeatherRepository metaWeatherRepository
    , IGenericRepository<WeatherSummary> weatherSummaryRepository
    , IGenericRepository<Weather> weatherRepository
    , IGenericRepository<LocationSearchResult> locationRepository
    , IGenericRepository<Source> sourceRepository
    , IMapper mapper)
    {
      _mapper = mapper;
      _metaWeatherRepository = metaWeatherRepository;
      _weatherSummaryRepository = weatherSummaryRepository;
      _weatherRepository = weatherRepository;
      _locationRepository = locationRepository;
      _sourceRepository = sourceRepository;
    }

    [Authorize]
    [HttpGet("location/{query}")]
    public async Task<ActionResult<List<LocationSearchResultDto>>> LocationSearchByQuery([FromRoute] string query)
    {
      return await _metaWeatherRepository.LocationSearchByQuery(query);

    }

  
    [HttpGet("{latitude}/{longitude}")]
    public async Task<ActionResult<List<LocationSearchResultDto>>> LocationSearchByLatLong([FromRoute] string latitude, [FromRoute] string longitude)
    {
      return await _metaWeatherRepository.LocationSearchByLatLong(latitude, longitude);

    }


    [Authorize]
    [HttpGet("{woeId}")]
    public async Task<ActionResult<WeatherSummaryDto>> LocationSearchByWoeId([FromRoute] int woeId)
    {
      return await _metaWeatherRepository.LocationSearchByWoeId(woeId);
    }

    [Authorize]
    [HttpGet("{woeId}/{year}/{month}/{day}")]
    public async Task<ActionResult<List<WeatherDto>>> LocationSearchByWoeIdAndDate([FromRoute] int woeId, [FromRoute] string year, [FromRoute] string month, [FromRoute] string day)
    {
      return await _metaWeatherRepository.LocationSearchByWoeIdAndDate(woeId, year, month, day);
    }

    
    [Authorize]
    [HttpGet("summary/{latitude}/{longitude}/{ipAddress}")]
    public async Task<List<WeatherSummaryDto>> SummaryByLatLong([FromRoute] string latitude, [FromRoute] string longitude, [FromRoute] string ipAddress)
    {
      var weatherSummaries =  _weatherSummaryRepository.ReturnQueryable()
      .Include(x=>x.Parent)
      .Include(x=>x.Sources)
      .Include(x=>x.ConsolidatedWeather)
      .ToList();

      var weatherSummariesDto = new List<WeatherSummaryDto>();

      foreach (var weatherToCheck in weatherSummaries)
      {
        if(weatherSummaries.Any(x=>x.ConsolidatedWeather.Min(x=>x.Created > DateTime.Now)))
        {           
          await deleteWeatherData(weatherToCheck);
        }
        if(!weatherSummaries.Any(x=>x.IpAddress==ipAddress) && weatherSummaries.Any()){
          await deleteWeatherData(weatherToCheck);
        }
      }

        weatherSummaries = weatherSummaries =  _weatherSummaryRepository.ReturnQueryable()
        .Include(x=>x.Parent)
        .Include(x=>x.Sources)
        .Include(x=>x.ConsolidatedWeather)
        .ToList();

      if (!weatherSummaries.Any())
      {
        var locationSearchResults = await this.LocationSearchByLatLong(latitude, longitude);
       
        foreach (var locationSearchResult in locationSearchResults.Value.ToArray())
        {
          var weatherSummaryDto = await this.LocationSearchByWoeId(locationSearchResult.WoeId);
          weatherSummariesDto.Add(weatherSummaryDto.Value);
          var weatherSummary = _mapper.Map<WeatherSummaryDto, WeatherSummary>(weatherSummaryDto.Value);
          weatherSummary.IpAddress=ipAddress;
          _weatherSummaryRepository.Add(weatherSummary);
          await _weatherSummaryRepository.Save();
        }
        return weatherSummariesDto;
      }
      return _mapper.Map<List<WeatherSummary>, List<WeatherSummaryDto>>(weatherSummaries);
    }

    private async Task deleteWeatherData(WeatherSummary weatherSummary){

        foreach (var source in weatherSummary.Sources)
           {
                _sourceRepository.Delete(source);
           }

           foreach (var consolidatedWeatherObject in weatherSummary.ConsolidatedWeather)
           {
               _weatherRepository.Delete(consolidatedWeatherObject);
           }

            _locationRepository.Delete(weatherSummary.Parent);
            _weatherSummaryRepository.Delete(weatherSummary);

           await _weatherSummaryRepository.Save();

    }
  }
}