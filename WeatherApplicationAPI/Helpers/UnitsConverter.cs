using WeatherApplicationAPI.Enums;
using WeatherServiceRestful.Enums;

namespace WeatherApplicationAPI.Helpers
{
    public static class UnitsConverter
    {
        public static TempUnits ConvertUnitsToTemperature(Units units)
        {
            switch(units)
            {
                case Units.imperial:
                    return TempUnits.Fahrenheit;
                case Units.metric:
                    return TempUnits.Celsius;
                default:
                    return TempUnits.Kelvin;                 
            }
        }
    }
}