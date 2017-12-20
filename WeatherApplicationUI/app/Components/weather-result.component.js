"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var WeatherResultComponent = /** @class */ (function () {
    function WeatherResultComponent() {
    }
    WeatherResultComponent.prototype.ngOnInit = function () {
    };
    WeatherResultComponent.prototype.getTempUnicodeChar = function () {
        return "\\00B0";
        //return "\\006B";
        //return "\\2109";
    };
    WeatherResultComponent = __decorate([
        core_1.Component({
            templateUrl: "app/Components/weather-result.component.html",
            styleUrls: ['app/Components/weather-card.css']
        })
    ], WeatherResultComponent);
    return WeatherResultComponent;
}());
exports.WeatherResultComponent = WeatherResultComponent;
//# sourceMappingURL=weather-result.component.js.map