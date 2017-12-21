using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WeatherApplicationAcceptanceTests.Abstract;

namespace WeatherApplicationAcceptanceTests.Pages
{
    public class WeatherApplicationResultPage : PageObject
    {
        [FindsBy(How = How.Id, Using = "temperature")]
        private IWebElement _temperature;

        [FindsBy(How = How.Id, Using = "humidity")]
        private IWebElement _humidity;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement _city;

        [FindsBy(How = How.Id, Using = "country")]
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

        public double Temperature()
        {
            return double.Parse(_temperature.Text);
        }

        public int Humidity()
        {
            return int.Parse(_humidity.Text);
        }
    }
}
