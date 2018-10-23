using System;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sidel.Droid.Authenticator))]
namespace Sidel.Droid
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

                var authResult = await authContext.AcquireTokenAsync(graphResourceUri, applicationId, new Uri(returnUri), new PlatformParameters((Activity)Forms.Context));

                return authResult;
            }
            catch (Exception exception)
            {
                var m = exception.Message;
                return null;
            }
        }
    }
}