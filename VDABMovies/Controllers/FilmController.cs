using System.Linq;
using System.Web.Mvc;
using VDABMovies.Models;
using VDABMovies.Models.Entities;

namespace VDABMovies.Controllers
{
    //[VDABAuthorizationFilter]
    [HandleError]
    public class FilmController : Controller
    {
        private moviesEntities _db = new moviesEntities();

        //Get /Films/GetFilmsVanGenre/{genreNr}
        public ActionResult GetFilmsVanGenre(int Id) {
            var genre = _db.Genres.Find(Id);
            var vm = new GetFilmsVanGenreViewModel();
            vm.GekozenGenre = genre;
            return View(vm);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (_db != null) {
                    _db.Dispose();
                }
            }
            base.Dispose(disposing);
        }

    }
}