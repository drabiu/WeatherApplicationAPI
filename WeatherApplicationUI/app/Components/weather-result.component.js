"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var weather_service_1 = require("../Service/weather.service");
var router_1 = require("@angular/router");
var WeatherResultComponent = /** @class */ (function () {
    function WeatherResultComponent(weatherService, activatedRoute) {
        var _this = this;
        this.weatherService = weatherService;
        this.activatedRoute = activatedRoute;
        this.loading = false;
        this.activatedRoute.params.subscribe(function (params) {
            _this.city = params["city"];
            _this.country = params["country"];
        });
    }
    WeatherResultComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loading = true;
        this.weatherService.get(this.country, this.city).subscribe(function (result) {
            _this.forecast = result;
        }, function (error) {
            _this.msg = 'The weather for ' + _this.city + 'in' + _this.country + ' could not be found';
            console.log(error);
        });
    };
    WeatherResultComponent = __decorate([
        core_1.Component({
            templateUrl: "app/Components/weather-result.component.html",
            styleUrls: ['app/Components/weather-card.css']
        }),
        __metadata("design:paramtypes", [weather_service_1.WeatherService, router_1.ActivatedRoute])
    ], WeatherResultComponent);
    return WeatherResultComponent;
}());
exports.WeatherResultComponent = WeatherResultComponent;
//# sourceMappingURL=weather-result.component.js.map