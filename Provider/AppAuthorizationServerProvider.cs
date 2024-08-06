using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Token_2.Migrations;
using Token_2.Models;
using Token_2.UserRepository;
using Token_2.Repository;

namespace Token_2.Provider
{
    public class AppAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if(!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.SetError("Invalid Client", "Client crededntisl not reviedr>>>>>>");
                context.Rejected();
                return;
            }

            Clientdetail client = (new ClientREpo()).ValidateClient(clientId, clientSecret);
   
            if(client != null)
            {
                context.OwinContext.Set<Clientdetail>("oauth.client", client);
                context.Validated(clientId);
            }
            else
            {
                context.SetError("Invalid Client", "Client crededntisl not valied>>>>>>");
                context.Rejected();
            }

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using ( UserRepo repo = new UserRepo())
            {
                var user = repo.ValidateUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Username or Password is incorrect!");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

                foreach (var role in user.Roles.Split(','))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
                }
                context.Validated(identity);

            }
        }

    }
}