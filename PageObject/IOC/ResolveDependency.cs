using PageObjectProject.Pages;
using PageObjectProject.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectProject.IOC
{
    public static class ResolveDependency
    {
        public static void RegisterAndResolveDependencies()
        {

            UnityWrapper.Register<IHomePage, HomePage>();
            UnityWrapper.Register<IBlog, Blog>();
            UnityWrapper.Register<ILoginPage, LoginPage>();
            UnityWrapper.Register<IHowItWorksPage, HowItWorksPage>();
            UnityWrapper.Register<IPrivacy, Privacy>();
            UnityWrapper.Register<IAccountPage, AccountPage>();
            UnityWrapper.Register<ILogoutPage, LogoutPage>();
            UnityWrapper.Register<IRegisterationPage, RegisterationPage>();
            UnityWrapper.Register<IConfirmRegisterPage, ConfirmRegisterPage>();
            UnityWrapper.Register<ISearchResults, SearchResults>();
        }
    }
}
