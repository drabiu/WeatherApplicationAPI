using TechTalk.SpecFlow;
using Xunit;
using NSubstitute;

namespace WeatherApplicationAcceptanceTests
{
    [Binding]
    public class LocalWeatherInGivenCitySteps
    {
        [Given(@"a webpage with a form")]
        public void GivenAWebpageWithAForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I type in ""(.*)""")]
        public void GivenITypeIn(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForWarsawPolandAccordingToTheOfficialWeatherReports()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForGdanskPolandAccordingToTheOfficialWeatherReports()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForBerlinGermanyAccordingToTheOfficialWeatherReports()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
