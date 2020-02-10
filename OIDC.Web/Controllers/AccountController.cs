using System.Web;
using System.Web.Mvc;
using Okta.AspNet;

namespace OIDC.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            HttpContext.GetOwinContext().Authentication.Challenge(OktaDefaults.MvcAuthenticationType);
            return new HttpUnauthorizedResult();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return View();
        }
    }
}