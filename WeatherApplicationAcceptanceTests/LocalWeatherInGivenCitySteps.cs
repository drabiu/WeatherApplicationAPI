using TechTalk.SpecFlow;
using Xunit;
using OpenQA.Selenium;
using WeatherApplicationAcceptanceTests.Pages;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using System;

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
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("WeatherApplicationUrl"));
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _weatherAppPage = new CheckWeatherApplicationPage(_driver);
        }
        
        [Given(@"I type in ""(.*)"" and ""(.*)""")]
        public void GivenITypeIn(string country, string city)
        {
            _weatherAppPage.ProvideLocationData(country, city);
        }
        
        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            _weatherAppResultPage = _weatherAppPage.Submit();
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForWarsawPolandAccordingToTheOfficialWeatherReports()
        {
            Assert.Equal("Warsaw", _weatherAppResultPage.City());
            Assert.Equal("PL", _weatherAppResultPage.Country());
            Assert.InRange<int>(_weatherAppResultPage.Humidity(), 0, 100);
            Assert.InRange<double>(_weatherAppResultPage.Temperature(), -90, 60);
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForGdanskPolandAccordingToTheOfficialWeatherReports()
        {
            Assert.Equal("Gdańsk", _weatherAppResultPage.City());
            Assert.Equal("PL", _weatherAppResultPage.Country());
            Assert.InRange<int>(_weatherAppResultPage.Humidity(), 0, 100);
            Assert.InRange<double>(_weatherAppResultPage.Temperature(), -90, 60);
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForBerlinGermanyAccordingToTheOfficialWeatherReports()
        {
            Assert.Equal("Berlin", _weatherAppResultPage.City());
            Assert.Equal("DE", _weatherAppResultPage.Country());
            Assert.InRange<int>(_weatherAppResultPage.Humidity(), 0, 100);
            Assert.InRange<double>(_weatherAppResultPage.Temperature(), -90, 60);
        }
    }
}
