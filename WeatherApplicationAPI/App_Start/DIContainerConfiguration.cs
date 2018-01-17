using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using WeatherApplicationAPI.WeatherService;
using WeatherApplicationAPI.WeatherService.Abstraction;
using WeatherServiceRestful;
using WeatherServiceRestful.Abstraction;

namespace WeatherApplicationAPI.App_Start
{
    public class DIContainerConfiguration
    {
        public IContainer Create(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WeatherServiceConfiguration>().As<IWeatherServiceRestConfiguration>();
            builder.RegisterType<WeatherServiceAdapter>().As<IWeatherService>();
            builder.RegisterType<WeatherServiceRest>().As<IWeatherServiceRest>();
            builder.RegisterType<RestClient>().As<IRestClient>();

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