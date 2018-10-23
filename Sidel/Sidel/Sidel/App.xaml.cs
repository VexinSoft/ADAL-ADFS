using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sidel
{
    public partial class App : Application
    {
        #region SIDEL TENANT informations
        public static string ApplicationId = "c2e2bbbe-130c-42f6-b509-3c49f7973fc6";
        public static string TenantUrl = "https://login.microsoftonline.com/2390cbd1-e663-4321-bc93-ba298637ce52";
        public static string ReturnUri = "https://localhost/";
        public static string GraphResourceUri = "https://graph.microsoft.com/";
        #endregion

        public static AuthenticationResult AuthenticationResult = null;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
