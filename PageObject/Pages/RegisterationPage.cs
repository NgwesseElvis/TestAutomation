using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class RegisterationPage:BaseClass, IRegisterationPage
    {
        private static readonly string pageName = "Register Page";
        private static readonly By emailField = By.CssSelector("div>input[name='email']");
        public RegisterationPage():base(pageName,emailField)
        {
        }

        public T ClickOnSubmitButton<T>() where T : class
        {
            var submitButton = By.CssSelector("button[type='submit']");
            ClickOnElement(submitButton);
            return GetPage<T>();
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            var locator = By.CssSelector("input[id='confirmpassword']");
            EnterText(locator, confirmPassword);
        }

        public void EnterEmailAddress(string email)
        {
            EnterText(emailField, email);
        }

        public void EnterFirstName(string firstName)
        {
            var locator = By.CssSelector("input[id='firstName']");
            EnterText(locator, firstName);
        }

        public void EnterLastName(string lastName)
        {
            var locator = By.CssSelector("input[id='lastName']");
            EnterText(locator, lastName);
        }

        public void EnterPassword(string password)
        {
            var locator = By.CssSelector("input[id='exampleInputPassword1']");
            EnterText(locator, password);
        }

        public void EnterUserName(string userName)
        {
            var locator = By.CssSelector("input[id='username']");
            EnterText(locator, userName);
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }
    }
}
