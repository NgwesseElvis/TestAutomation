using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class RegisterUserTest : Hook
    {
        private IHomePage _homePage;
        private ILoginPage _loginPage;
        private IRegisterationPage _registerationPage;
        private IConfirmRegisterPage _confirmRegisterPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _loginPage = _homePage.ClickOnLoginLink<LoginPage>();
            _registerationPage = _loginPage.ClickOnRegisterLink<RegisterationPage>();
            _registerationPage.EnterUserName("Administrator1");
            _registerationPage.EnterFirstName("Ajang Elvis");
            _registerationPage.EnterLastName("Ngwesse");
            _registerationPage.EnterEmailAddress("Ngwesse@Specops.se");
            _registerationPage.EnterPassword("1234567");
            _registerationPage.EnterConfirmPassword("1234567");
            _confirmRegisterPage = _registerationPage.ClickOnSubmitButton<ConfirmRegisterPage>();
        }

        [Test, Category("Register new user")]
        public void AssertRegistrationText()
        {
            var result = _confirmRegisterPage.VerifyRegisterationText();
            Assert.IsTrue(result);
        }

        [Test, Category("Register new user")]
        public void AssertPageTitel()
        {
            var result = _confirmRegisterPage.GetPageTitel();
            var titel = "Register";
            Assert.AreEqual(result,titel);

        }
        //
    }
}