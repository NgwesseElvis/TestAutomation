using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaseProject.Config;
using BaseProject.Factory;
using System.Threading;

namespace BaseProject.Reporting
{
    public class BaseReport : DriverFactory
    {
        
        private static ExtentReports extent;
        private static ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;
        private static ThreadLocal<ExtentTest> _threadLocal = new ThreadLocal<ExtentTest>();

        public static ExtentTest getExtentTest
        {
            get
            {
                return _threadLocal.Value;
            }
            set
            {
                _threadLocal.Value = value;
            }
        }

        public static void CreateTest(string name)
        {
            extent = new ExtentReports();
            CreateReport();
            test = extent.CreateTest(name);
            getExtentTest = test;
            var startTime = extent.ReportStartDateTime;
            getExtentTest.Info($"Test Started at : {startTime}");
        }

        private static void CreateReport()
        {
            var path = $@"{FilePath.GetFilePathFromDirectory()}";
            htmlReporter = new ExtentHtmlReporter(path);
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Testing");
            extent.AddSystemInfo("Environment", "Test Environment");
            extent.AddSystemInfo("UserName", "Ngwesse Elvis");
            extent.AddSystemInfo("os", "Windows 10");
        }

        public static void FlushTest()
        {
            var endTime = extent.ReportEndDateTime;
            Info($"Test ended at : {endTime}");
            extent.Flush();
        }

        public static void Skip(string message)
        {
            getExtentTest.Log(Status.Skip, message);
        }

        public static void Warning(string message)
        {
            getExtentTest.Log(Status.Warning, message);
        }

        public static void Fail(string message)
        {
            getExtentTest.Log(Status.Fail, message);
            ScreenShort.TakeScreenShot(message);
        }

        public static void Info(string message)
        {
            getExtentTest.Log(Status.Info, message);
        }

        public static void Pass(string message)
        {
            getExtentTest.Log(Status.Pass,message);
        }
    }
}
