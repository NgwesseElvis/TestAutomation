using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class InvalidLoginUserTest : Hook
    {
        private IHomePage _homePage;
        private ILoginPage _loginPage;
        private static readonly string TestName = "Invalid user Login";

        public InvalidLoginUserTest() : base(TestName)
        {

        }

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _loginPage = _homePage.ClickOnLoginLink<LoginPage>();
            _loginPage.EnterUserName("Elvis");
            _loginPage.EnterPassword("1234567");
            _loginPage = _loginPage.ClickOnSubmitButton<LoginPage>();
        }

        [Test, Category("Invalid user Login")]
        public void AssertLoginText()
        {
            var result = _loginPage.GetPageTitel();
            var titel = "Login";
            Assert.AreEqual(result, titel);
        }
    }
}