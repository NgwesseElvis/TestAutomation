using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BaseProject.Config;
using BaseProject.Factory;

namespace BaseProject.Reporting
{
    public class BaseReport : DriverFactory
    {
        
        private static ExtentReports extent;
        private static ExtentTest testCreated;
        private static ExtentHtmlReporter htmlReporter;
        private static object locker = new object();

        public static void CreateTest(string name)
        {
            extent = new ExtentReports();
            CreateReport();

            lock (locker)
            {
                testCreated = extent.CreateTest(name);
            }
           
            var startTime = extent.ReportStartDateTime;
            testCreated.Info($"Test Started at : {startTime}");
        }

        private static void CreateReport()
        {
            var path = FilePath.GetFilePathFromDirectory();
            htmlReporter = new ExtentHtmlReporter(@"C:\\Users\\ajang\\Desktop\\Repositories\\TestAutomation\\BaseProject\\Reporting\\index.html");
            //htmlReporter = new ExtentHtmlReporter(path);
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
            testCreated.Log(Status.Skip, message);
        }

        public static void Warning(string message)
        {
            testCreated.Log(Status.Warning, message);
        }

        public static void Fail(string message)
        {
            testCreated.Log(Status.Fail, message);
            ScreenShort.TakeScreenShot(message);
        }

        public static void Info(string message)
        {
            testCreated.Log(Status.Info, message);
        }

        public static void Pass(string message)
        {
            testCreated.Log(Status.Pass,message);
        }
    }
}
