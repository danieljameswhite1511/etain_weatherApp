import { Component, OnInit } from '@angular/core';
import { IpLocation } from '../shared/models/ipLocation';
import { LocationInfo } from '../shared/models/locationInfo';
import { WeatherService } from '../WeatherApp/weather.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public ipLocation = new IpLocation();
  public locationsInfo: LocationInfo[];

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {

    this.weatherService.getIpLocation().subscribe((ipLocation: IpLocation) => {

      this.ipLocation=ipLocation;

      console.log(this.ipLocation);

      this.weatherService.locationSearchByLatLong(this.ipLocation.latitude, this.ipLocation.longitude)
      .subscribe(locationsInfo =>{

        this.locationsInfo = locationsInfo;

        console.log(this.locationsInfo);

      });




      });

  }

}
