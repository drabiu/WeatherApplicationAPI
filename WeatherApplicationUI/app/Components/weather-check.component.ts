import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ILocation } from '../Models/location';
import { IForecastResult } from '../Models/forecast-result';

@Component({
    templateUrl: `app/Components/weather-check.component.html`
})

export class WeatherCheckComponent implements OnInit 
{
    location: ILocation;
    msg: string;
    loading: boolean = false;
    locationForm: FormGroup;

    constructor(private formBuilder: FormBuilder , private weatherService: WeatherService) {
        this.locationForm = this.formBuilder.group({
            City: ['', Validators.required],
            Country: ['', Validators.required]
        });
    }

    ngOnInit() {

    }
}