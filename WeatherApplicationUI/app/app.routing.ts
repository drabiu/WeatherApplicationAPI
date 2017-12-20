import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WeatherCheckComponent } from './components/weather-check.component';
import { WeatherResultComponent } from './components/weather-result.component'

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: WeatherCheckComponent },
    { path: 'weather', component: WeatherResultComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);