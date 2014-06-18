using System.Linq;
using System.Web.Mvc;
using VDABMovies.Models;
using VDABMovies.Models.Entities;

namespace VDABMovies.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult VDABLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        
        public ActionResult VDABLogin(VDABLoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //gaan kijken of gebruiker in de db bestaat
                using (var moviesEnities = new moviesEntities())
                {
                    
                    var user = moviesEnities.Klanten.Where(u => u.Naam == model.Naam && u.PostCode.Equals(model.Postcode)).FirstOrDefault();
                    if (user != null)
                    {
                        // user bestaat, session login starten met naam gebruiker en logged in gaan
                        Session["login"] = user;
                        
                        moviesEnities.Dispose(); //zou niet moeten want in using maar connection blijft open ...
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Naam - Postcode niet gevonden in systeem.");
                    }
                }
            }

            // Iets ging kapot ...
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult VDABLogout() {
            Session.Remove("login");
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
       

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}