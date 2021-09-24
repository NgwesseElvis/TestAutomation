namespace PageObjectProject.Pages.Interfaces
{
    public interface IRegisterationPage
    {
        string GetPageTitel();
        void EnterUserName(string userName);
        void EnterFirstName(string firstName);
        void EnterLastName(string lastName);
        void EnterEmailAddress(string email);
        void EnterPassword(string password);
        void EnterConfirmPassword(string confirmPassword);
        T ClickOnSubmitButton<T>() where T : class;
    }
}
