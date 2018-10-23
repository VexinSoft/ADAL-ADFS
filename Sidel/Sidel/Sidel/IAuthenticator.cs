using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sidel
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> Authenticate(string tenantUrl, string graphResourceUri, string applicationId, string returnUri);
    }
}
