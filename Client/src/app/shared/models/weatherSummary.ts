import { Consolidated_Weather } from "./consolidated_Weather";
import { LocationInfo } from "./locationInfo";
import { Source } from "./source";

export class WeatherSummary{
    title: string;
    location_Type: string;
    woeId: number;
    latLong: string;
    timeZone: string;
    time: Date;
    sun_Rise: Date;
    sun_Set: Date;
    time_Zone: string
    consolidated_Weather: Consolidated_Weather[];
    parent: LocationInfo;
    sources: Source[];
    
}