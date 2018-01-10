using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using NSubstitute;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using WeatherApplicationAPI;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRestful;
using WeatherServiceRestful.Abstraction;
using WeatherServiceRestful.Models;
using Microsoft.Owin;
using WeatherApplicationIntegrationTests.Stubs;
using WeatherServiceRestful.Enums;

[assembly: OwinStartup(typeof(TestStartup))]
namespace WeatherApplicationIntegrationTests.Stubs
{
    public class TestStartup : Startup
    {
        public override IContainer ConfigureDI(ContainerBuilder builder)
        {
            var config = Substitute.For<IWeatherServiceRestConfiguration>();
            config.ApiUrl.Returns("http://url");
            config.Units.Returns(Units.Metric);
            config.ApiKey.Returns("aaa");

            var restClient = Substitute.For<IRestClient>();
            var weatherService = Substitute.For<WeatherServiceRest>(config, restClient);
            //weatherService.CallWeatherService(Arg.Any<string>(), Arg.Any<string>()).Returns(x => {
            //    return new WeatherService()
            //    {
            //        Main = new Main() { Humidity = 10, Temp = 10 },
            //        Name = (string)x[1],
            //        Sys = new Sys() { Country = (string)x[0] }
            //    };
            //});   
            weatherService.CallWeatherService(Arg.Any<string>(), Arg.Any<string>()).Returns(
                new WeatherService()
                {
                    Main = new Main() { Humidity = 10, Temp = 10 },
                    Name = "a",
                    Sys = new Sys() { Country = "b" }
                });

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterInstance(config).As<IWeatherServiceRestConfiguration>();
            builder.RegisterType<WeatherServiceAdapter>().As<IWeatherService>();
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterInstance(weatherService).AsSelf();

            RegisterAutoMapper(builder);

            return builder.Build();
        }

        private void RegisterAutoMapper(ContainerBuilder builder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
            .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
            .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg => {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
