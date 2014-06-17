using System.Web.Mvc;

namespace VDABMovies.Controllers
{
    
    public class HomeController : Controller
    {
        
        //[VDABAuthorizationFilter]
        public ActionResult Index() {
            return View();
        }
    }
}