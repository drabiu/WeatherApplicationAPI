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
                case Units.Imperial:
                    return TempUnits.Fahrenheit;
                case Units.Metric:
                    return TempUnits.Celsius;
                default:
                    return TempUnits.Kelvin;                 
            }
        }
    }
}