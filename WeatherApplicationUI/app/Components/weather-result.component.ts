import { Component, OnInit, ViewChild } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';
import { Global } from '../Shared/global';

@Component({
    templateUrl: `app/Components/weather-result.component.html`,
    styleUrls: ['app/Components/weather-card.css']
})

export class WeatherResultComponent implements OnInit {

    ngOnInit() {

    }

    getTempUnicodeChar() {
        return Global.CELSIUS_UNICODE_CHAR;
    }
}