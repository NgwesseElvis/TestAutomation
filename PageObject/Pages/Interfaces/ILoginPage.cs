namespace PageObjectProject.Pages.Interfaces
{
    public interface ILoginPage
    {
        T ClickOnHomeLink<T>() where T : class;
        T ClickOnHowItWorksLink<T>() where T : class;
        T ClickOnRegisterLink<T>() where T : class;
        T ClickOnBlogLink<T>() where T : class;
        string GetPageTitel();
        void EnterUserName(string username);
        void EnterPassword(string password);
        T ClickOnSubmitButton<T>() where T : class;
    }
}
