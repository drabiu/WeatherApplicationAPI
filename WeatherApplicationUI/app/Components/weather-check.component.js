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
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var WeatherCheckComponent = /** @class */ (function () {
    function WeatherCheckComponent(formBuilder, weatherService, router) {
        this.formBuilder = formBuilder;
        this.weatherService = weatherService;
        this.router = router;
        this.loading = false;
        this.locationForm = this.formBuilder.group({
            City: ['', forms_1.Validators.required],
            Country: ['', forms_1.Validators.required]
        });
    }
    WeatherCheckComponent.prototype.ngOnInit = function () {
    };
    WeatherCheckComponent.prototype.getWeather = function (location) {
        var _this = this;
        this.loading = true;
        this.weatherService.get(location.value.Country, location.value.City).subscribe(function (result) {
            _this.forecast = result;
            _this.router.navigate(['/weather']);
        }, function (error) {
            _this.msg = 'The weather for ' + location.value.City + 'in' + location.value.Country + ' could not be found';
            console.log(error);
        });
    };
    WeatherCheckComponent = __decorate([
        core_1.Component({
            templateUrl: "app/Components/weather-check.component.html"
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder, weather_service_1.WeatherService, router_1.Router])
    ], WeatherCheckComponent);
    return WeatherCheckComponent;
}());
exports.WeatherCheckComponent = WeatherCheckComponent;
//# sourceMappingURL=weather-check.component.js.map