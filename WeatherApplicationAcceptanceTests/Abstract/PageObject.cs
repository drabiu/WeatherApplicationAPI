using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WeatherApplicationAcceptanceTests.Abstract
{
    public abstract class PageObject
    {
        protected IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
