using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class TensorAcceleratedTest : Hook
    {
        private IHomePage _homePage;
        private IHowItWorksPage _howItWorksPage;
        private IBlog _blog;
        private static readonly string TestName = "Verify Tensor Accelerated link";

        public TensorAcceleratedTest() : base(TestName)
        {

        }

        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _howItWorksPage = _homePage.ClickOnViewDetails_TensorAccelerated<HowItWorksPage>();
        }

        [Test, Category("Verify Tensor Accelerated link")]
        public void AssertHowItWorksPageTitel()
        {
            var result = _howItWorksPage.GetPageTitel();
            var titel = "How It Works";
            Assert.AreEqual(result, titel);
        }

        [Test, Category("Verify Tensor Accelerated link")]
        public void AssertTensorAcceleratedText()
        {
            var boolResults = _howItWorksPage.VerifyTensorAcceleratedTextDisplayed();
            Assert.IsTrue(boolResults);
        }

        [Test, Category("Verify Tensor Accelerated link")]
        public void VerifyBlogPageTitel()
        {
            _blog = _howItWorksPage.ClickOnBlogLink<Blog>();
            var result = _blog.GetPageTitel();
            var titel = "Blog";
            Assert.AreEqual(result, titel);
        }
    }
}