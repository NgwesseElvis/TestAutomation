using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class HomePage : BaseClass, IHomePage
    {
        private static readonly string pageName = "Home Page";
        private static readonly By warShipImage = By.CssSelector("div>img");

        public HomePage():base(pageName,warShipImage)
        {
        }

        public T ClickOnBlogLink<T>() where T : class
        {
            var locator = By.CssSelector("li>a[href*='/Blog']");
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

        public T ClickOnPrivacyLink<T>() where T : class
        {
            var locator = By.CssSelector("div>a[href*='Privacy']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnViewDetails_MachineLearning<T>() where T : class
        {
            var locator = By.CssSelector("p>a[href*='machineLearning']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnViewDetails_TensorAccelerated<T>() where T : class
        {
            var locator = By.CssSelector("p>a[href*='tensorAccelerated']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnViewDetails_TheBlockChain<T>() where T : class
        {
            var locator = By.CssSelector("p>a[href*='theBlockchain']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public void Search(string text)
        {
            var locator = By.CssSelector("form>input[name='search']");
            EnterText(locator,text);
        }

        public bool VerifyElementContainsText(string text)
        {
            var locator = By.CssSelector("form>input[name='search']");
            var boolResults = DoesElementContainText(locator,text);
            return boolResults;
        }
    }
}
