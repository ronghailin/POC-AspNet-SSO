using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace MvcWebApp1.Security
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "About":
                    return AuthorizeAbout(context);

                default:
                    return Nok();
            }
        }

        Task<bool> AuthorizeAbout(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.HasClaim("role", "admin"));

                case "Write":
                    return Eval(context.Principal.HasClaim("role", "admin"));

                default:
                    return Nok();
            }
        }
    }
}