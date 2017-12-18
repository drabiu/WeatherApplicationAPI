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
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.imperial);

            Assert.Equal(TempUnits.Fahrenheit, unit);
        }

        [Fact]
        public void UnitsConverterShouldReturnCelsius()
        {
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.metric);

            Assert.Equal(TempUnits.Celsius, unit);
        }

        [Fact]
        public void UnitsConverterShouldReturnKelvin()
        {
            var unit = UnitsConverter.ConvertUnitsToTemperature(Units.other);

            Assert.Equal(TempUnits.Kelvin, unit);
        }
    }
}
