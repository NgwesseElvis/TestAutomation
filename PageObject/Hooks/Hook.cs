using BaseProject.DriverFactory;
using BaseProject.IDrivers;
using NUnit.Framework;

namespace PageObjectProject.Hooks
{
    public class Hook : DriverFactory
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitDriver(BrowserType.Chrome);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            CloseDriver();
        }
    }
}
