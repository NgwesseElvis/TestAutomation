using BaseProject.IDrivers;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;

namespace BaseProject.Factory
{
    public class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> storedDriver = new();


        public static IWebDriver GetDriver()
        {
            return DriverStored;
        }

        public static IWebDriver DriverStored
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

        public static void InitDriver()
        {
            var browserType = Configuration.BrowserType.ToLower();
            switch (browserType)
            {
                case "chrome":
                    ChromeDriverWeb chrmoedriverInstance = new();
                    chrmoedriverInstance.InitDriver();
                    DriverStored = (IWebDriver)chrmoedriverInstance.Driver;
                    break;

                case "firefox":
                    FireFoxDriverWeb firefoxdriverInstance = new();
                    firefoxdriverInstance.InitDriver();
                    DriverStored = (IWebDriver)firefoxdriverInstance.Driver;
                    break;

                case "ie":
                    InternetExplorerDriverWeb iedriverInstance = new();
                    iedriverInstance.InitDriver();
                    DriverStored = (IWebDriver)iedriverInstance.Driver;
                    break;

                case "remote":
                    RemoteChromeDriverWeb remoteChrmoedriverInstance = new();
                    remoteChrmoedriverInstance.InitDriver();
                    DriverStored = (IWebDriver)remoteChrmoedriverInstance.Driver;

                    break;
            }

        }

        public static void CloseDriver()
        {
            var driverInstance = GetDriver();

            try
            {
                driverInstance.Quit();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }finally
            {

                if (driverInstance.ToString().Contains("null"))
                {
                    KillBrowser();
                }
            }
        }

        private static void KillBrowser()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    if (s == "iexplore" || s == "edge" || s == "chrome" || s == "firefox")
                        //process.Container.Dispose();
                        process.Kill();
                    process.Close();
                    process.Dispose();
                }
            }
        }
    }
}
