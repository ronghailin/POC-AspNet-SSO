﻿using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using MvcWebApp1;
using MvcWebApp1.Security;
using Owin;
using SharedConfiguration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup("Startup1", typeof(Startup))]

namespace MvcWebApp1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "implicitclient-cardeal",
                Authority = Constants.BaseAddress,
                RedirectUri = "http://localhost:57870/",
                ResponseType = "id_token token",
                Scope = "openid email write",
                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = SecurityTokenValidated
                }
            });

            app.UseResourceAuthorization(new AuthorizationManager());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        static Task SecurityTokenValidated(SecurityTokenValidatedNotification<OpenIdConnectMessage,
            OpenIdConnectAuthenticationOptions> notification)
        {
            var token = notification.ProtocolMessage.AccessToken;
            if (!string.IsNullOrEmpty(token))
            {
                notification.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", token));
            }

            return Task.FromResult(true);
        }
    }
}