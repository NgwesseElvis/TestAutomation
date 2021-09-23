using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;

namespace BaseProject.IDrivers
{
    public class RemoteChromeDriverWeb : IDrivers
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
                option.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Eager;
                option.AcceptInsecureCertificates = true;
                return option;
            }
        }

        object IDrivers.DesiredCapabilities => throw new NotImplementedException();

        public void InitDriver()
        {
            IWebDriver driver = new RemoteWebDriver(new Uri($"{Configuration.hubIpAddress}"), (ICapabilities)DesiredCapabilities, TimeSpan.FromSeconds(int.Parse(Configuration.remoteWebDriverWaitTime)));
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(int.Parse(Configuration.pageLoadWaitTime));
            driver.Navigate().GoToUrl(Configuration.BaseUrl);
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
