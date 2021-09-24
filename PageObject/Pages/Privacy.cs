using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class Privacy : BaseClass, IPrivacy
    {
        private static readonly string pageName = "Privacy Page";
        private static readonly By privacyText = By.CssSelector("main>h1");

        public Privacy():base(pageName,privacyText)
        {
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }
    }
}
