using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BaseProject.IDrivers
{
    public class ChromeDriverWeb : IDrivers
    {
        public object Driver
        {
            get; set;
        }

        public object DesiredCapabilities
        {
            get
            {
                ChromeOptions option = new();
                option.AddArgument("no-sandbox");
                option.AddArgument("--start-maximized");
                option.PageLoadStrategy = PageLoadStrategy.Eager;
                option.AcceptInsecureCertificates = true;
                return option;
            }
        }

        public void InitDriver()
        {
            IWebDriver driver = new ChromeDriver((ChromeOptions)DesiredCapabilities);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(int.Parse(Configuration.pageLoadWaitTime));
            driver.Navigate().GoToUrl(Configuration.BaseUrl);
            driver.Manage().Cookies.DeleteAllCookies();
            Driver = driver;
        }
    }
}
