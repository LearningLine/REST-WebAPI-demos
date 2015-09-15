using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Mod06
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IOAuthAuthorizationServerProvider provider = new OAuthAuthorizationServerProvider()
            {
                OnValidateClientAuthentication = ctx =>
                {
                    ctx.Validated();
                    return Task.FromResult(true);
                },

                OnGrantResourceOwnerCredentials = ctx =>
                {
                    if (ctx.UserName == "maurice" && ctx.Password == "secret")
                    {
                        ctx.Validated(new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, ctx.UserName),
                        }, "password"));
                    }

                    return Task.FromResult(true);
                }
            };




            OAuthAuthorizationServerOptions serverConfig = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),

                Provider = provider

            };
            app.UseOAuthAuthorizationServer(serverConfig);



            OAuthBearerAuthenticationOptions oauthConfig = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(oauthConfig);


            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}");

            //config.MessageHandlers.Add();
            app.UseWebApi(config);
        }
    }
}