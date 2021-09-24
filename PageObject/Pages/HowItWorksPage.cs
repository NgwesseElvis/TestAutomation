using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class HowItWorksPage : BaseClass, IHowItWorksPage
    {
        private static readonly string pageName = "HowItWork's Page";
        private static readonly By howItsWorksText = By.XPath(".//h1[contains(text(),'How It Works')]");
        public HowItWorksPage():base(pageName,howItsWorksText)
        {
        }

        public T ClickOnBlogLink<T>() where T : class
        {
            var locator = By.CssSelector("li>a[href*='/Blog']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnHomeLink<T>() where T : class
        {
            var locator = By.XPath(".//a[contains(text(),'Home')]");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public bool VerifyMachineLearningTextDisplayed()
        {
            var locator = By.CssSelector("div>h2[name='machineLearning']");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }

        public bool VerifyTensorAcceleratedTextDisplayed()
        {
            var locator = By.CssSelector("div>h2[name='tensorAccelerated']");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }

        public bool VerifyTheBlockchainTextDisplayed()
        {
            var locator = By.CssSelector("div>h2[name='theBlockchain']");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }
    }
}
