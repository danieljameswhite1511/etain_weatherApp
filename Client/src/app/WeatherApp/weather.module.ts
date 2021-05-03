import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { WeatherComponent } from './weather.component';
import { WeatherRoutingModule } from './weather-routing.module';
import { WeatherSearchComponent } from './weather-search/weather-search.component';
import { WeatherSummaryCardComponent } from './weather-summary-card/weather-summary-card.component';

@NgModule({
  declarations: [WeatherComponent, WeatherSearchComponent, WeatherSummaryCardComponent],
  imports: [
    CommonModule,
    WeatherRoutingModule,
    SharedModule
  ]
})
export class WeatherModule { }
