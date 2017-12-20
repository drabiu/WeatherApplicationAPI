import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WeatherCheckComponent } from './components/weather-check.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: WeatherCheckComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);