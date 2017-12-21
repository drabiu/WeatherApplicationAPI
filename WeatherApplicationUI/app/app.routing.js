"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var weather_check_component_1 = require("./components/weather-check.component");
var weather_result_component_1 = require("./components/weather-result.component");
var appRoutes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: weather_check_component_1.WeatherCheckComponent },
    { path: 'weather/:city/:country', component: weather_result_component_1.WeatherResultComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map