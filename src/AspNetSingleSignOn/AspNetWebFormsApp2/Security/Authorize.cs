using System;
using System.Web;

namespace AspNetWebFormsApp2.Security
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorizeAttribute : Attribute
    {
        public AuthorizeAttribute()
        {
            var ctx = HttpContext.Current.GetOwinContext();
            if (!ctx.Authentication.User.Identity.IsAuthenticated)
            {
                ctx.Response.StatusCode = 401;
            }
        }
    }
}