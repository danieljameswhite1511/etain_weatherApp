import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IpLocation } from '../shared/models/ipLocation';
import { LocationInfo } from '../shared/models/locationInfo';
import { WeatherSummary } from '../shared/models/weatherSummary';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  public imageUrl: string = 'https://www.metaweather.com/static/img/weather/png/';
  private apiUrl: string = 'https://localhost:5003/api/Weather/';

  constructor(private http: HttpClient) { }

  getIpLocation(){
    return this.http.get<IpLocation>('https://geolocation-db.com/json/');
  }

  locationSearchByQuery(query: string){
    const token = localStorage.getItem('token');
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get(this.apiUrl + 'location/' + query, {headers});
  }

  locationSearchByLatLong(latitude: string, longitude: string){


    return this.http.get<LocationInfo[]>(this.apiUrl + latitude + '/' + longitude);
  }

 locationSearchByWoeId(woeId: number) : Observable<WeatherSummary>{
  const token = localStorage.getItem('token');
  let headers = new HttpHeaders();
  headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get<WeatherSummary>(this.apiUrl + woeId, {headers});
  }

  locationSearchByWoeIdAndDate(woeId: number, year: string, month: string, day: string){
    const token = localStorage.getItem('token');
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get(this.apiUrl + woeId + '/' + year + '/' + month + '/' + day, {headers});
  }

  summaryByLatLong(latitude: string, longitude: string, ipAddress: string){
    const token = localStorage.getItem('token');
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get<WeatherSummary[]>(this.apiUrl + 'summary/' + latitude + '/' + longitude + '/' + ipAddress, {headers});
  }
}

