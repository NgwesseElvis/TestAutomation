using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace BaseProject.IDrivers
{
    public class FireFoxDriverWeb : IDrivers
    {

        public object Driver
        {
            get;set;
        }

        public object DesiredCapabilities
        {
            get
            {
                FirefoxOptions option = new();
                option.AddArgument("no-sandbox");
                option.AddArgument("--start-maximized");
                option.PageLoadStrategy = PageLoadStrategy.Eager;
                option.AcceptInsecureCertificates = true;
                return option;
            }
        }

        public void InitDriver()
        {
            IWebDriver driver = new FirefoxDriver((FirefoxOptions)DesiredCapabilities);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(int.Parse(Configuration.pageLoadWaitTime));
            driver.Navigate().GoToUrl(Configuration.BaseUrl);
            Driver = driver;
        }
    }
}
