using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace OWinTokenAuth
{

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});

            // here we need to inject our verification, get user from database with maching credientials, if found then grand access otherwise invalid grant
            if(!context.UserName.Equals("U") || context.Password.Equals("P"))
            {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            // you can add any possible claims here... e.g name, role, department, current status or anything
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "admin"));

            context.Validated(identity);

        }
    }
}