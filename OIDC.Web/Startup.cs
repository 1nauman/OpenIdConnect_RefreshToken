using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using OIDC.Web;
using Okta.AspNet;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace OIDC.Web
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
                ClientId = "0oa1wbf6kb1fhpp1D357",
                ClientSecret = "G4as-yX3nbfTa8ruA1O8mk0R4WMZTuqD3J-gvPw8",
                RedirectUri = "https://localhost:44344/authorization-code/callback",
                PostLogoutRedirectUri = "https://localhost:44344/account/logout",
                Scope = new List<string> { "openid", "profile", "email" }
            });
        }
    }
}