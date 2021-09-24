namespace PageObjectProject.Pages.Interfaces
{
    public interface IHowItWorksPage
    {
        T ClickOnHomeLink<T>() where T : class;
        T ClickOnBlogLink<T>() where T : class;
        string GetPageTitel();
        bool VerifyMachineLearningTextDisplayed();
        bool VerifyTensorAcceleratedTextDisplayed();
        bool VerifyTheBlockchainTextDisplayed();
    }
}
