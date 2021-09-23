using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace BaseProject.IDrivers
{
    public class InternetExplorerDriverWeb
    {
        public object Driver
        {
            get; set;
        }

        public object DesiredCapabilities
        {
            get
            {
                InternetExplorerOptions option = new InternetExplorerOptions();
                option.EnsureCleanSession = true;
                option.RequireWindowFocus = false;
                option.IgnoreZoomLevel = false;
                option.IntroduceInstabilityByIgnoringProtectedModeSettings = false;
                option.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Top;
                return option;
            }
        }

        public void InitDriver()
        {
            IWebDriver driver = new InternetExplorerDriver((InternetExplorerOptions)DesiredCapabilities);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(int.Parse(Configuration.pageLoadWaitTime));
            driver.Navigate().GoToUrl(Configuration.BaseUrl);
            driver.Manage().Cookies.DeleteAllCookies();
            Driver = driver;
        }
    }
}
