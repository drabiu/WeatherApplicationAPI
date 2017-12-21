import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';
import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';

@Component({
    templateUrl: `app/Components/weather-check.component.html`,
    styleUrls: ['app/Components/weather-card.css']
})

export class WeatherCheckComponent implements OnInit 
{  
    locationForm: FormGroup; 

    constructor(private formBuilder: FormBuilder, private router: Router) {
        this.locationForm = this.formBuilder.group({
            City: ['', Validators.required],
            Country: ['', Validators.required]
        });
    }

    ngOnInit() {

    }

    getWeather(location: FormGroup) {
        let city = location.value.City;
        let country = location.value.Country;

        this.router.navigate(['/weather/' + city + '/' + country]);      
    }
}