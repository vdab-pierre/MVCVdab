using System.Web.Mvc;
using VDABMovies.Models.Entities;

namespace VDABMovies.Controllers
{
    
    public class HomeController : Controller
    {
        
        [VDABAuthorizationFilter]
        public ActionResult Index() {
            return View();
        }
    }
}