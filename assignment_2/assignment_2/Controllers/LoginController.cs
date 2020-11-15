using System.Web.Mvc;
using System.Web.Security;
using assignment_2.Models;
using Umbraco.Web.Mvc;

namespace assignment_2.Controllers
{
    public class LoginController: SurfaceController
    {
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "The username or password provided is incorrect");
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToCurrentUmbracoPage();
        }
    }

   
    
}