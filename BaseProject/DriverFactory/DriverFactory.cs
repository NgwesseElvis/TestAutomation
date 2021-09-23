using BaseProject.IDrivers;
using OpenQA.Selenium;
using System.Threading;

namespace BaseProject.DriverFactory
{
    public class DriverFactory
    {
        private static readonly ThreadLocal<object> storedDriver = new();


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

        public static void InitDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    ChromeDriverWeb chrmoedriverInstance = new();
                    chrmoedriverInstance.InitDriver();
                    DriverStored = chrmoedriverInstance.Driver;
                    break;

                case BrowserType.FireFox:
                    FireFoxDriverWeb firefoxdriverInstance = new();
                    firefoxdriverInstance.InitDriver();
                    DriverStored = firefoxdriverInstance.Driver;
                    break;

                case BrowserType.InternetExplorer:
                    InternetExplorerDriverWeb iedriverInstance = new();
                    iedriverInstance.InitDriver();
                    DriverStored = iedriverInstance.Driver;
                    break;

                case BrowserType.remote:
                    RemoteChromeDriverWeb remoteChrmoedriverInstance = new();
                    remoteChrmoedriverInstance.InitDriver();
                    DriverStored = remoteChrmoedriverInstance.Driver;

                    break;
            }

        }

        public static void CloseDriver()
        {
            IWebDriver driver = (IWebDriver)DriverStored;
            driver.Quit();
            DriverStored = null;
        }
    }
}
