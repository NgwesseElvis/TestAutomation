namespace PageObjectProject.Pages.Interfaces
{
    public interface IAccountPage
    {
        T ClickOnLogoutButton<T>() where T : class;
        string GetPageTitel();
        bool VerifyLoginText();
    }
}
