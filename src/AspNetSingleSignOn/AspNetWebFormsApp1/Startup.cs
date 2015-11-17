using IdentityServer3.AccessTokenValidation;
using Owin;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspNetWebFormsApp1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333",
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1" }
            });

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}