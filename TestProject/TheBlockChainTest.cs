using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class TheBlockChainTest : Hook
    {
        private IHomePage _homePage;
        private IHowItWorksPage _howItWorksPage;
        private IPrivacy _privacy;

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _howItWorksPage = _homePage.ClickOnViewDetails_TheBlockChain<HowItWorksPage>();
        }

        [Test, Category("Verify The BlockChain link")]
        public void AssertHowItWorksPageTitel()
        {
            var result = _howItWorksPage.GetPageTitel();
            var titel = "How It Works";
            Assert.AreEqual(result, titel);
        }

        [Test, Category("Verify The BlockChain link")]
        public void AssertTheBlockChainText()
        {
            var boolResults = _howItWorksPage.VerifyTheBlockchainTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify The BlockChain link")]
        public void VerifyPrivacyPageTitel()
        {
            _privacy = _howItWorksPage.ClickOnPrivacyLink<Privacy>();
            var result = _privacy.GetPageTitel();
            var titel = "Privacy";
            Assert.AreEqual(result, titel);
        }
    }
}