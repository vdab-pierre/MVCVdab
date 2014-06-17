using System.Web.Mvc;

namespace VDABMovies.Controllers
{
    public class HomeController : Controller
    {
        
        //[VDABAuthorizationFilter]
        public ActionResult Welkom() {
            //ViewBag.loginNaam = Session["login"].ToString();
            return View();
        }
    }
}