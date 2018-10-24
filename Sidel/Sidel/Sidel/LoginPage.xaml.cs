using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sidel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

	    private async void Login_OnClicked(object sender, EventArgs e)
	    {
	        try
	        {
	            var data = await DependencyService.Get<IAuthenticator>().Authenticate(App.TenantUrl, App.ResourceUri, App.ApplicationId, App.ReturnUri);
	            App.AuthenticationResult = data;
	            NavigateTopage(data);
	        }
	        catch (Exception exception)
	        {
	            var message = exception.Message;
	        }
	    }

	    private async void NavigateTopage(AuthenticationResult data)
	    {
	        var userName = data.UserInfo.GivenName + " " + data.UserInfo.FamilyName;
	        var token = data.AccessToken;

	        await Navigation.PushModalAsync(new HomePage(userName, token));
	    }
    }
}