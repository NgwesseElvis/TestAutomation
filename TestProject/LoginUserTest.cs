using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class LoginUserTest : Hook
    {
        private IHomePage _homePage;
        private ILoginPage _loginPage;
        private IAccountPage _accountPage;
        private ILogoutPage _logoutPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _loginPage = _homePage.ClickOnLoginLink<LoginPage>();
            _loginPage.EnterUserName("administrator");
            _loginPage.EnterPassword("xisE4P5DsjT4Hq");
            _accountPage = _loginPage.ClickOnSubmitButton<AccountPage>();
        }

        [Test, Category("Login user")]
        public void AssertLoginText()
        {
            var boolResult = _accountPage.VerifyLoginText();
            var result = _accountPage.GetPageTitel();
            var titel = "Login";
            Assert.IsTrue(boolResult);
            Assert.AreEqual(result, titel);
        }

        [Test, Category("Login user")]
        public void AssertLogoutPageText()
        {
            _logoutPage = _accountPage.ClickOnLogoutButton<LogoutPage>();
            var boolResult = _logoutPage.VerifyLogoutText();
            Assert.IsTrue(boolResult);
        }

        [Test, Category("Login user")]
        public void AssertLogoutPageTitel()
        {
            var result = _logoutPage.GetPageTitel();
            var titel = "Logged Out";
            Assert.AreEqual(result, titel);
        }
    }
}