﻿import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { WeatherCheckComponent } from './components/weather-check.component';
import { WeatherResultComponent } from './components/weather-result.component'
import { WeatherService } from './Service/weather.service'

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing],
    declarations: [AppComponent, WeatherCheckComponent, WeatherResultComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, WeatherService],
    bootstrap: [AppComponent]
})

export class AppModule { }