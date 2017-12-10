using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WeatherApplicationAcceptanceTests.Abstract;

namespace WeatherApplicationAcceptanceTests.Pages
{
    public class CheckWeatherApplicationPage : PageObject
    {
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement _countryInput;

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement _cityInput;

        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement _submitButton;

        public CheckWeatherApplicationPage(IWebDriver driver) : base(driver)
        {
        }

        public void ProvideLocationData(string country, string city)
        {
            _countryInput.SendKeys(country);
            _countryInput.SendKeys(city);
        }

        public WeatherApplicationResultPage Submit()
        {
            _submitButton.Click();

            return new WeatherApplicationResultPage(_driver);
        }
    }
}
