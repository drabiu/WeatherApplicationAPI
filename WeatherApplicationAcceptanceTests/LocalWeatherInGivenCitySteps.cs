using TechTalk.SpecFlow;
using Xunit;
using NSubstitute;
using OpenQA.Selenium;
using WeatherApplicationAcceptanceTests.Pages;
using OpenQA.Selenium.Chrome;

namespace WeatherApplicationAcceptanceTests
{
    [Binding]
    public class LocalWeatherInGivenCitySteps
    {
        private CheckWeatherApplicationPage _weatherAppPage;
        private WeatherApplicationResultPage _weatherAppResultPage;
        private IWebDriver _driver;

        [BeforeScenario()]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [AfterScenario()]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Given(@"a webpage with a form")]
        public void GivenAWebpageWithAForm()
        {
            _driver.Navigate().GoToUrl("");
            _weatherAppPage = new CheckWeatherApplicationPage(_driver);
        }
        
        [Given(@"I type in ""(.*)""")]
        public void GivenITypeIn(string p0)
        {
            _weatherAppPage.ProvideLocationData("", "");
        }
        
        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            _weatherAppResultPage = _weatherAppPage.Submit();
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
