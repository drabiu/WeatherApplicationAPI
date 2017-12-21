using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using WeatherApplicationAcceptanceTests.Abstract;

namespace WeatherApplicationAcceptanceTests.Pages
{
    public class CheckWeatherApplicationPage : PageObject
    {
        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement _countryInput;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement _cityInput;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement _submitButton;

        public CheckWeatherApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public void ProvideLocationData(string country, string city)
        {
            _countryInput.SendKeys(country);
            _cityInput.SendKeys(city);
        }

        public WeatherApplicationResultPage Submit()
        {
            _submitButton.Click();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            Thread.Sleep(5000);

            return new WeatherApplicationResultPage(_driver);
        }
    }
}
