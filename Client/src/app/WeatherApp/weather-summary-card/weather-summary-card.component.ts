import { Component, Input, OnInit } from '@angular/core';
import { WeatherSummary } from '../../shared/models/weatherSummary';

@Component({
  selector: 'app-weather-summary-card',
  templateUrl: './weather-summary-card.component.html',
  styleUrls: ['./weather-summary-card.component.scss']
})
export class WeatherSummaryCardComponent implements OnInit {

  @Input() weatherSummary: WeatherSummary;
  constructor() { }

  ngOnInit(): void {
  }

}
