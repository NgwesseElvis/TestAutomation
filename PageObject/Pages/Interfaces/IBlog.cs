namespace PageObjectProject.Pages.Interfaces
{
    public interface IBlog
    {
        T ClickOnHomeLink<T>() where T : class;
        T ClickOnHowItWorksLink<T>() where T : class;
        bool VerifyCybrCoinTextDisplayed();
        bool VerifyCybrhitsrecord100minedcoinsTextDisplayed();
        bool VerifyZimbabweannouncesadoptionofCybrTextDisplayed();
        T ClickOnLoginLink<T>() where T : class;
        string GetPageTitel();
    }
}
