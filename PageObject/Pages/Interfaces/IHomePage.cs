namespace PageObjectProject.Pages.Interfaces
{
    public interface IHomePage
    {
        T ClickOnLoginLink<T>() where T : class;
        T ClickOnBlogLink<T>() where T : class;
        T ClickOnHowItWorksLink<T>() where T : class;
        void Search(string text);
        T ClickOnViewDetails_MachineLearning<T>() where T : class;
        T ClickOnViewDetails_TensorAccelerated<T>() where T : class;
        T ClickOnViewDetails_TheBlockChain<T>() where T : class;
        string GetPageTitel();
        T ClickOnPrivacyLink<T>() where T : class;
        bool VerifyElementContainsText(string text);
    }
}
