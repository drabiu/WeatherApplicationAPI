import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';
import { Global } from '../Shared/global';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Observable } from "rxjs/Observable";

@Component({
    templateUrl: `app/Components/weather-result.component.html`,
    styleUrls: ['app/Components/weather-card.css']
})

export class WeatherResultComponent implements OnInit {  

    forecast: Observable<IForecastResult>;
    loading: boolean = false;
    msg: string;
    city: '';
    country: '';

    constructor(private weatherService: WeatherService, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.params.subscribe(
            (params: Params) => {
                this.city = params["city"];
                this.country = params["country"];
            }
        );
    }

    ngOnInit() {  
        this.loading = true;
        this.weatherService.get(this.country, this.city).subscribe(
            result => {
                this.forecast = result;
            },
            error => {
                this.msg = 'The weather for ' + this.city + 'in' + this.country + ' could not be found'
                console.log(error);
            });
    }
}