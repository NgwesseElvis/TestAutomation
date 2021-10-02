using BaseProject.Factory;
using BaseProject.Reporting;
using NUnit.Framework;
using PageObjectProject.IOC;

namespace PageObjectProject.Hooks
{
    public class Hook : BaseReport
    {
        public string _TestName { get; set; }

        public Hook(string testName)
        {
            _TestName = testName;
        }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ResolveDependency.RegisterAndResolveDependencies();
            InitDriver();
            CreateTest(_TestName);
            Info("Opening Browser");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Info("Closing Browser");
            FlushTest();
            CloseDriver();
        }
    }
}
