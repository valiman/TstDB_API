﻿using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TstDB_API.App_Start.Providers;

[assembly: OwinStartup(typeof(TstDB_API.App_Start.Startup))]
namespace TstDB_API.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Specific order
            app.UseCors(CorsOptions.AllowAll); //Allows cors; good for api. bad for main-page. Must precede any defined endpoints.
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}