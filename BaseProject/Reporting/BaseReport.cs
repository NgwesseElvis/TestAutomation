using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaseProject.Config;
using BaseProject.Factory;

namespace BaseProject.Reporting
{
    public class BaseReport : DriverFactory
    { 
        private static ExtentReports extent;
        private static ExtentTest testInstance;

        public static void CreateTest(string name)
        {
            extent = new ExtentReports();
            CreateReport();
            ExtentTest test = extent.CreateTest(name);
            //All tests object will be stored in the ThreadLocal class ref. variable
            ExtTest.SetExtentTest = test;
            testInstance = ExtTest.GetExtentTest();
        }

        private static void CreateReport()
        {
            var path = $@"{FilePath.GetFilePathFromDirectory()}";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Testing");
            extent.AddSystemInfo("Environment", "Test Environment");
            extent.AddSystemInfo("UserName", "Ngwesse Elvis");
            extent.AddSystemInfo("os", "Windows 10");
        }

        public static void FlushTest()
        {
            extent.Flush();
        }

        public static void Skip(string message)
        {
            testInstance.Log(Status.Skip, message);
        }

        public static void Warning(string message)
        {
            testInstance.Log(Status.Warning, message);
        }

        public static void Fail(string message)
        {
            testInstance.Log(Status.Fail, message);
            ScreenShort.TakeScreenShot(message);
        }

        public static void Info(string message)
        {
            testInstance.Log(Status.Info, message);
        }

        public static void Pass(string message)
        {
            testInstance.Log(Status.Pass,message);
        }
    }
}
