using BaseProject.IDrivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.Threading;

namespace BaseProject.DriverFactory
{
    internal class DriverFactory
    {
        private static readonly ThreadLocal<object> storedDriver = new();
        public static DriverOptions option;
        public static ChromeOptions chromeOptions;

        public static DriverType GetDriver<DriverType>()
        {
            return (DriverType)DriverStored;
        }

        public static object DriverStored
        {
            get
            {
                if (storedDriver == null)
                    return null;
                else
                    return storedDriver.Value;
            }
            set
            {
                storedDriver.Value = value;
            }
        }

        internal static IWebDriver InitializeDriver(string browserType)
        {
            IWebDriver _driver = null;
            var browser = browserType.ToLower();

            try
            {
                switch (browser)
                {

                    case "chrome":
                        chromeOptions = new ChromeOptions();
                        //chromeOptions.PlatformName = "LINUX";
                        chromeOptions.AddArgument("no-sandbox");
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--start-maximized");
                        chromeOptions.AcceptInsecureCertificates = true;
                        chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

                        break;

                    case "firefox":
                        option = new FirefoxOptions();
                        //option.PlatformName = "LINUX";
                        break;

                    case "localhost":
                        _driver = new FirefoxDriver();
                        _driver.Manage().Window.Size = new Size(1920, 1080);
                        _driver.Manage().Window.Maximize();
                        break;
                }


                if (browser.Equals("chrome"))
                {
                    _driver = new RemoteWebDriver(new Uri($"{Configuration.hubIpAddress}"), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(int.Parse(Configuration.remoteWebDriverWaitTime)));
                    _driver.Manage().Window.Size = new Size(1920, 1080);
                    _driver.Manage().Window.Maximize();
                }
                else if (browser.Equals("firefox"))
                {
                    _driver = new RemoteWebDriver(new Uri($"{Configuration.hubIpAddress}"), option.ToCapabilities(), TimeSpan.FromSeconds(int.Parse(Configuration.remoteWebDriverWaitTime)));
                    _driver.Manage().Window.Size = new Size(1920, 1080);
                    _driver.Manage().Window.Maximize();
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;

            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(Configuration.elementLoadWaitTime));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(int.Parse(Configuration.pageLoadWaitTime));
            _driver.Manage().Cookies.DeleteAllCookies();
            var allowsDetection = (OpenQA.Selenium.IAllowsFileDetection)_driver;
            allowsDetection.FileDetector = new LocalFileDetector();
            DriverStored = _driver;
            return _driver;
        }

        internal static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            DriverStored = null;
        }
    }
}
