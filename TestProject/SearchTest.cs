using NUnit.Framework;
using PageObjectProject.Hooks;
using PageObjectProject.IOC;
using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;

namespace TestProject
{
    [TestFixture()]
    [Parallelizable]
    public class SearchTest : Hook
    {
        private IHomePage _homePage;
        private ISearchResults _searchResults;
        private readonly string searchText = "Europe";


        [OneTimeSetUp]
        public void Setup()
        {
            _homePage = UnityWrapper.Resolve<IHomePage>();
            _homePage.Search(searchText);
            _searchResults = _homePage.PressEnter<SearchResults>();
        }

        [Test, Category("Search text")]
        public void AssertSearchText()
        {
            var boolResult = _searchResults.VerifySearchResultText(searchText);
            Assert.IsTrue(boolResult);
        }

        [Test, Category("Search text")]
        public void AssertPageTitel()
        {
            var result = _searchResults.GetPageTitel();
            var titel = "Search Results";
            Assert.AreEqual(result, titel);
        }
    }
}