using AventStack.ExtentReports;
using BaseProject.Factory;
using OpenQA.Selenium;

namespace BaseProject.Reporting
{
    public class ScreenShort : DriverFactory
    {
        public static MediaEntityModelProvider TakeScreenShot(string name)
        {
            var screenShort = ((ITakesScreenshot)DriverStored).GetScreenshot().AsBase64EncodedString;
            var image = MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShort,name).Build();
            return image;
        }
    }
}
