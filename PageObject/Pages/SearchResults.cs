using BaseProject.BaseClass;
using OpenQA.Selenium;
using PageObjectProject.Pages.Interfaces;

namespace PageObjectProject.Pages
{
    public class SearchResults : BaseClass, ISearchResults
    {
        private static readonly string pageName = "Search Page";
        private static readonly By searchResults = By.XPath(".//h1[contains(text(),'Search Results')]");

        public SearchResults():base(pageName,searchResults)
        {
        }

        public bool VerifySearchResultText(string searchText)
        {
            var text = $"Search results for: {searchText}";
            var locator = By.CssSelector("div>main>div");
            var result = DoesElementContainText(locator,text);
            return result;
        }

        public string GetPageTitel()
        {
            var titel = Driver.Title;
            return titel;
        }
    }
}
