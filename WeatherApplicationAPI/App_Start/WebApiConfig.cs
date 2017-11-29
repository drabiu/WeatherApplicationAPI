using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRest;

namespace WeatherApplicationAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            IWeatherService weather =  new WeatherServiceAdapter(new WeatherServiceRestful(new WeatherServiceConfiguration()));
            weather.GetCurrentWeatherForecast("Gdynia", "Poland");
        }
    }
}
