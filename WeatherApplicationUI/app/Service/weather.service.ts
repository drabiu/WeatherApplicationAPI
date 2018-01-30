import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Global } from '../Shared/global';

@Injectable()
export class WeatherService {

    constructor(private _http: Http) { }

   
    get(country: string, city: string): Observable<any> {
        let getHeaders = new Headers();
        //getHeaders.append('Content-Type', 'application/json'); 
        //getHeaders.append('Access-Control-Allow-Origin', '*');

        let options = new RequestOptions({ headers: getHeaders });

        return this._http.get(Global.BASE_WEATHER_ENDPOINT + country + '/' + city, options)
            .map(response => {
                if (response.status === 200) {
                    return <any>response.json();
                }
                else {
                    return this.handleError(response);
                }
            })
            // .do(data => console.log("All: " + JSON.stringify(data)))
            .catch((error: any) => {
                return this.handleError(error)
            });
    }

    private handleError(error: any) {
        console.error(error);
        return Observable.throw(error);
    }

}