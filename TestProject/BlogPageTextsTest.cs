using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class BlogPageTextsTest : Hook
    {
        private IHomePage _homePage;
        private IBlog _blog;
        private ILoginPage _loginPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _blog = _homePage.ClickOnBlogLink<Blog>();
        }

        [Test, Category("Verify Blog Page Texts")]
        public void AssertCybrCoinText()
        {
            var boolResults = _blog.VerifyCybrCoinTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify Blog Page Texts")]
        public void AssertCybrhitsrecord100minedcoinsText()
        {
            var boolResults = _blog.VerifyCybrhitsrecord100minedcoinsTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify Blog Page Texts")]
        public void AssertZimbabweannouncesadoptionofCybrText()
        {
            var boolResults = _blog.VerifyZimbabweannouncesadoptionofCybrTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify Blog Page Texts")]
        public void VerifyLoginPageTitel()
        {
            _loginPage = _blog.ClickOnLoginLink<LoginPage>();
            var result = _loginPage.GetPageTitel();
            var titel = "Login";
            Assert.AreEqual(result, titel);
        }
    }
}