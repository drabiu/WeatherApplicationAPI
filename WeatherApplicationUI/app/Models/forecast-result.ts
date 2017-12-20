import { ILocation } from '../Models/location';
import { ITemperature } from '../Models/temperature';

export interface IForecastResult {
    Location: ILocation,
    Temperature: ITemperature,
    Humidity: number
}