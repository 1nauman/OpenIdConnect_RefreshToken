using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOktaMvc(new OktaMvcOptions
            {
                OktaDomain = "https://dev-376017.okta.com",
                AuthorizationServerId = "aus1n7nfubeHAG5GG357",
                ClientId = "0oa1n752ktbFdxXMw357",
                ClientSecret = "7Wz4jdh2Ap38jhCKbTMYtXrt9FcgHsBHDYPby3or",
                RedirectUri = "https://localhost:44344/authorization-code/callback",
                PostLogoutRedirectUri = "https://localhost:44344/account/logout",
                Scope = new List<string> { "openid", "profile", "email" }
            });
        }
    }
}