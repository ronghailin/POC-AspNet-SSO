using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.UI;

namespace AspNetWebFormsApp2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties
                    {
                        RedirectUri = "http://localhost:2671/Default"
                    },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            else
            {
                var user = User as ClaimsPrincipal;
            }
        }

        protected void ButtonClaims_Click(object sender, EventArgs e)
        {
            Server.Transfer("Claims.aspx", true);
        }

        protected void ButtonSignout_Click(object sender, EventArgs e)
        {
            Server.Transfer("Signout.aspx", true);
        }
    }
}