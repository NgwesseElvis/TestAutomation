using BaseProject.BaseClass;
using OpenQA.Selenium;

namespace PageObjectProject.Pages
{
    public class ConfirmRegisterPage:BaseClass, IConfirmRegisterPage
    {
        private static readonly string pageName = "ConfirmRegisteration Page";
        private static readonly By UserCreatedText= By.CssSelector("main>div[role='alert']");
        public ConfirmRegisterPage():base(pageName,UserCreatedText)
        {
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }

        public bool VerifyRegisterationText()
        {
            var text = "User created. You can now login.";
            var boolResults = DoesElementContainText(UserCreatedText, text);
            return boolResults;
        }
    }
}
