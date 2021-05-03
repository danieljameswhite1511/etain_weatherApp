import { Component, OnInit, Output } from '@angular/core';
import { WeatherSummary } from '../../shared/models/weatherSummary';
import { WeatherService } from '../weather.service';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { LocationInfo } from '../../shared/models/locationInfo';


@Component({
  selector: 'app-weather-search',
  templateUrl: './weather-search.component.html',
  styleUrls: ['./weather-search.component.scss']
})
export class WeatherSearchComponent implements OnInit {

  public form: FormGroup = new FormGroup({});
  public weatherSummary: WeatherSummary;
  @Output() public weatherSummaries = [new WeatherSummary()];
  public location: LocationInfo;
  public locations = [new LocationInfo()];
  public displayNoResultsFound: boolean=false;

  constructor(private weatherService: WeatherService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(){
    this.form = this.formBuilder.group({
      search: new FormControl('')
    });
  }

  submit(){

    this.weatherSummaries =  [new WeatherSummary()];

    console.log(this.form.value.search);

    this.weatherService.locationSearchByQuery(this.form.value.search).subscribe((locations: LocationInfo[])=>{

      this.locations=locations;



      this.locations.forEach(location => {

        this.weatherService.locationSearchByWoeId(location.woeId).subscribe((weatherSummary: WeatherSummary)=>{

          this.weatherSummary=weatherSummary;
          this.weatherSummaries.push(this.weatherSummary);
          if(this.weatherSummaries.length>1){
            this.displayNoResultsFound=false
          }
          else{
            this.displayNoResultsFound=true;
          }

        })

      });

      console.log(this.weatherSummaries);


    });
  }
}
