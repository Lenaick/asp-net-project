using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Projet3.Models;

namespace Projet3
{
    public partial class Startup
    {
        // Pour plus d'informations sur la configuration de l'authentification, visitez https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            string loginPath = "/Account/Login";
            string logoutPath = "/Account/LogOff";
            if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("/Admin/"))
            {
                loginPath = "/Admin/Account/Login";
                logoutPath = "/Admin/Account/LogOff";
            }

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString(loginPath),
                LogoutPath = new PathString(logoutPath),
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0)
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}