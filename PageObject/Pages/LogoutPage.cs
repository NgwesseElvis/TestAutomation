using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class LogoutPage: BaseClass, ILogoutPage
    {
        private static readonly string pageName = "Login Page";
        private static readonly By logOutText = By.CssSelector("div>main>div");
        public LogoutPage():base(pageName,logOutText)
        {

        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public bool VerifyLogoutText()
        {
            var text = "You are now logged out.";
            var locator = By.CssSelector("div>main>div");
            var boolResults = DoesElementContainText(locator, text);
            return boolResults;
        }
    }
}
