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
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.Temperature, opt => opt.UseValue(new Temperature()))
                .ForPath(dest => dest.Temperature.Value, opt => opt.MapFrom(src => src.Main.Temp))
                .ForPath(dest => dest.Temperature.Format, opt => opt.MapFrom(src => UnitsConverter.ConvertUnitsToTemperature(configuration.Units)))
                .ForMember(dest => dest.Location, opt => opt.UseValue(new Location()))
                .ForPath(dest => dest.Location.City, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Location.Country, opt => opt.MapFrom(src => src.Sys.Country));
                
        }
    }
}