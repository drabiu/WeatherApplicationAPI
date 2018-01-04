using Xunit;
using WeatherApplicationAPI.Helpers;
using WeatherServiceRestful.Enums;
using WeatherApplicationAPI.Enums;

namespace WeatherApplicationUnitTests
{
    public class HelpersTests
    {
        [Fact]
        public void UnitsConverterShouldReturnFahrenheit()
        {
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.Imperial);

            Assert.Equal(TempUnits.Fahrenheit, unit);
        }

        [Fact]
        public void UnitsConverterShouldReturnCelsius()
        {
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.Metric);

            Assert.Equal(TempUnits.Celsius, unit);
        }

        [Fact]
        public void UnitsConverterShouldReturnKelvin()
        {
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.Other);

            Assert.Equal(TempUnits.Kelvin, unit);
        }
    }
}
