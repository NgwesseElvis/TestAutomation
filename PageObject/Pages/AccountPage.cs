using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class AccountPage : BaseClass, IAccountPage
    {
        private static readonly string pageName = "Login Page";
        private static readonly By logOutButton = By.XPath(".//a[contains(text(),'Log Out')]");
        public AccountPage():base(pageName,logOutButton)
        {
        }

        public T ClickOnLogoutButton<T>() where T : class
        {
            ClickOnElement(logOutButton);
            return GetPage<T>();
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public bool VerifyLoginText()
        {
            var text = "You are already logged in.";
            var locator = By.CssSelector("div>main>div");
            var boolResults = DoesElementContainText(locator,text);
            return boolResults;
        }
    }
}
