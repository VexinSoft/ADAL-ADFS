using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Sidel.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Authenticator))]
namespace Sidel.iOS
{
    public class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> Authenticate(string tenantUrl, string graphResourceUri, string applicationId, string returnUri)
        {
            try
            {
                var authContext = new AuthenticationContext(tenantUrl);

                if (authContext.TokenCache.ReadItems().Any())
                    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().FirstOrDefault()?.Authority);

                var authResult = await authContext.AcquireTokenAsync(graphResourceUri, applicationId, new Uri(returnUri),
                    new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController));

                return authResult;
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                return null;
            }
        }
    }
}