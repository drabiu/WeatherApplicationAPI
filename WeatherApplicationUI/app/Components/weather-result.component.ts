import { Component, OnInit, ViewChild } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';

@Component({
    templateUrl: `app/Components/weather-result.component.html`,
    styleUrls: ['app/Components/weather-card.css']
})

export class WeatherResultComponent implements OnInit {

    ngOnInit() {

    }

    getTempUnicodeChar() {
        return "\\00B0";
        //return "\\006B";
        //return "\\2109";
    }
}