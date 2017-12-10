using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WeatherApplicationAcceptanceTests.Abstract;

namespace WeatherApplicationAcceptanceTests.Pages
{
    public class WeatherApplicationResultPage : PageObject
    {
        [FindsBy(How = How.Name, Using = "temp")]
        private IWebElement _temperature;

        [FindsBy(How = How.Name, Using = "humidity")]
        private IWebElement _humidity;

        [FindsBy(How = How.Name, Using = "format")]
        private IWebElement _format;

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement _city;

        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement _country;

        public WeatherApplicationResultPage(IWebDriver driver) : base(driver)
        {

        }

        public string City()
        {
            return _city.Text;
        }

        public string Country()
        {
            return _country.Text;
        }

        public string Temperature()
        {
            return _temperature.Text;
        }

        public string Humidity()
        {
            return _humidity.Text;
        }
    }
}
