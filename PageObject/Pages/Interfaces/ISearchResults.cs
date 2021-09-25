namespace PageObjectProject.Pages.Interfaces
{
    public interface ISearchResults
    {
        bool VerifySearchResultText(string searchText);
        string GetPageTitel();
    }
}
