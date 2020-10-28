using System;
using System.Configuration;
using Abp.Owin;
using TestDBTest.Api.Controllers;
using TestDBTest.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DinkToPdf;
using DinkToPdf.Contracts;

[assembly: OwinStartup(typeof(Startup))]

namespace TestDBTest.Web
{
    public class Startup
    {
		
		// This method gets called by the runtime. Use this method to add services to the container.

		public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
         
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                // evaluate for Persistent cookies (IsPermanent == true). Defaults to 14 days when not set.
                ExpireTimeSpan = new TimeSpan(int.Parse(ConfigurationManager.AppSettings["AuthSession.ExpireTimeInDays.WhenPersistent"] ?? "14"), 0, 0, 0),
                SlidingExpiration = bool.Parse(ConfigurationManager.AppSettings["AuthSession.SlidingExpirationEnabled"] ?? bool.FalseString)
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();
        }
    }
}
