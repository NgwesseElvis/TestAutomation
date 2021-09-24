using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class LoginPage : BaseClass, ILoginPage
    {
        private static readonly string pageName = "Login Page";
        private static readonly By submitButton = By.CssSelector("button[type='submit']");

        public LoginPage():base(pageName,submitButton)
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

        public T ClickOnHowItWorksLink<T>() where T : class
        {
            var locator = By.CssSelector("li>a[href*='/HowItWorks']");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnRegisterLink<T>() where T : class
        {
            var locator = By.XPath(".//a[contains(text(),'Register')]");
            ClickOnElement(locator);
            return GetPage<T>();
        }

        public T ClickOnSubmitButton<T>() where T : class
        {
            ClickOnElement(submitButton);
            return GetPage<T>();
        }

        public void EnterPassword(string password)
        {
            var locator = By.CssSelector("input[name='password']");
            EnterText(locator,password);
        }

        public void EnterUserName(string username)
        {
            var locator = By.CssSelector("input[id='userName']");
            EnterText(locator, username);
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }
    }
}
