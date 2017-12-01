using AutoMapper;
using WeatherApplicationAPI.Helpers;
using WeatherApplicationAPI.Models;
using WeatherServiceRestful.Abstraction;

namespace WeatherApplicationAPI.Profiles
{
    public class WeatherForecastProfile : Profile
    {
        public WeatherForecastProfile(IWeatherServiceRestConfiguration configuration)
        {
            CreateMap<WeatherServiceRestful.Models.WeatherService, WeatherForecast>()
                .ForMember(dest => dest.humidity, opt => opt.MapFrom(src => src.main.humidity))
                .ForMember(dest => dest.temperature, opt => opt.UseValue(new Temperature()))
                .ForPath(dest => dest.temperature.value, opt => opt.MapFrom(src => src.main.temp))
                .ForPath(dest => dest.temperature.format, opt => opt.MapFrom(src => UnitsConverter.ConvertUnitsToTemperature(configuration.Units)))
                .ForMember(dest => dest.location, opt => opt.UseValue(new Location()))
                .ForPath(dest => dest.location.city, opt => opt.MapFrom(src => src.name))
                .ForPath(dest => dest.location.country, opt => opt.MapFrom(src => src.sys.country));
                
        }
    }
}