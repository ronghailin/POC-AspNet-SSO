using System;
using System.Web;
using System.Web.UI;

namespace AspNetWebFormsApp2
{
    public partial class _Signout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Request.GetOwinContext().Authentication.SignOut();
            Server.Transfer("Default.aspx", true);
        }
    }
}