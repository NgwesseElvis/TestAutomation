using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class MachineLearningTest : Hook
    {
        private IHomePage _homePage;
        private IHowItWorksPage _howItWorksPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _howItWorksPage = _homePage.ClickOnViewDetails_MachineLearning<HowItWorksPage>();
        }

        [Test, Category("Verify Machine Learning link")]
        public void AssertHowItWorksPageTitel()
        {
            var result = _howItWorksPage.GetPageTitel();
            var titel = "How It Works";
            Assert.AreEqual(result, titel);
        }

        [Test, Category("Verify Machine Learning link")]
        public void AssertMachineLearningText()
        {
            var boolResults = _howItWorksPage.VerifyMachineLearningTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify Machine Learning link")]
        public void VerifyHomePageTitel()
        {
            _homePage = _howItWorksPage.ClickOnHomeLink<HomePage>();
            var result = _homePage.GetPageTitel();
            var titel = "Home Page";
            Assert.AreEqual(result, titel);
        }
    }
}