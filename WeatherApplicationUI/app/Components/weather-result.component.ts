import { Component, OnInit, ViewChild } from '@angular/core';
import { WeatherService } from '../Service/weather.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IForecastResult } from '../Models/forecast-result';

@Component({
    template: `app/Components/weather-result.component.html`
})

export class WeatherResultComponent {
}