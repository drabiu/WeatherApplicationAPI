import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';
import { Router } from '@angular/router';

@Component({
    templateUrl: `app/Components/weather-check.component.html`,
    styleUrls: ['app/Components/weather-card.css']
})

export class WeatherCheckComponent implements OnInit 
{
    msg: string;
    loading: boolean = false;
    locationForm: FormGroup;
    forecast: IForecastResult;

    constructor(private formBuilder: FormBuilder, private weatherService: WeatherService, private router: Router) {
        this.locationForm = this.formBuilder.group({
            City: ['', Validators.required],
            Country: ['', Validators.required]
        });
    }

    ngOnInit() {

    }

    getWeather(location: FormGroup) {
        this.loading = true;
        this.weatherService.get(location.value.Country, location.value.City).subscribe(
            result => {
                this.forecast = result;
                this.router.navigate(['/weather']);
            },         
            error => {
                this.msg = 'The weather for ' + location.value.City + 'in' + location.value.Country + ' could not be found' 
                console.log(error);
            });
    }
}