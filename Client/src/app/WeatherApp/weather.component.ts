import { Component, OnInit } from '@angular/core';
import { Consolidated_Weather } from '../shared/models/consolidated_Weather';
import { IpLocation } from '../shared/models/ipLocation';
import { LocationInfo } from '../shared/models/locationInfo';
import { WeatherSummary } from '../shared/models/weatherSummary';
import { WeatherService } from './weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {

  public ipLocation = new IpLocation();
  public locationsInfo = [new LocationInfo()];
  public locationInfo = new LocationInfo();
  public weatherSummaries =  [new WeatherSummary()];

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
   this.getSummaryDataByIpLocationInfo();
  }

  getSummaryDataByIpLocationInfo(){
    this.weatherService.getIpLocation().subscribe((ipLocation: IpLocation)=>{
      this.ipLocation=ipLocation;
      this.weatherService.summaryByLatLong(this.ipLocation.latitude, this.ipLocation.longitude, this.ipLocation.IPv4)
      .subscribe((weatherSummaries: WeatherSummary[])=>{
        this.weatherSummaries = weatherSummaries;

        console.log(this.weatherSummaries);
      })
    })
  }

  getSummaryByLatLong(lat: string, long: string, ipAddress: string){

    this.weatherService.summaryByLatLong(lat, long, ipAddress)
    .subscribe((weatherSummaries: WeatherSummary[])=>{
      this.weatherSummaries = weatherSummaries;

      console.log(this.weatherSummaries);
    })

  }


  getLocationsByIpLocationInfo(){
    this.weatherService.getIpLocation().subscribe(async (ipLocation: IpLocation) => {
      this.ipLocation=ipLocation;

      this.weatherService.locationSearchByLatLong(this.ipLocation.latitude, this.ipLocation.longitude)
      .subscribe(async (locationsInfo: LocationInfo[])=>{
        this.locationsInfo=locationsInfo;

        });
      })
  }
}
