using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class Blog : BaseClass, IBlog
    {
        private static readonly string pageName = "Blog Page";
        private static readonly By blogText = By.CssSelector("div>main>h1");
        public Blog():base(pageName,blogText)
        {
        }

        public T ClickOnHomeLink<T>() where T : class
        {
            var locator = By.XPath(".//a[contains(text(),'Home')]");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnHowItWorksLink<T>() where T : class
        {
            var locator = By.CssSelector("li>a[href*='/HowItWorks']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnLoginLink<T>() where T : class
        {
            var locator = By.CssSelector("li>a[href*='Login']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public bool VerifyCybrCoinTextDisplayed()
        {
            var locator = By.XPath(".//h3[contains(text(),'Cybr Coin')]");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }

        public bool VerifyCybrhitsrecord100minedcoinsTextDisplayed()
        {
            var locator = By.XPath(".//h3[contains(text(),'Cybr hits record 100 mined coins')]");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }

        public bool VerifyZimbabweannouncesadoptionofCybrTextDisplayed()
        {
            var locator = By.XPath(".//h3[contains(text(),'Zimbabwe announces adoption of Cybr')]");
            var boolResults = IsElementDisplayed(locator);
            return boolResults;
        }
    }
}
