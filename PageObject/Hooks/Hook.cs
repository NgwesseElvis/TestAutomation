using BaseProject.Factory;
using BaseProject.IDrivers;
using NUnit.Framework;
using PageObjectProject.IOC;

namespace PageObjectProject.Hooks
{
    public class Hook : DriverFactory
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ResolveDependency.RegisterAndResolveDependencies();
            InitDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            CloseDriver();
        }
    }
}
