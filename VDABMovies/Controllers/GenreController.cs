using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDABMovies.ViewModels;
using VDABMovies.ViewModels.Entities;

namespace VDABMovies.Controllers
{
    //[VDABAuthorizationFilter]
    //[HandleError]
    public class GenreController : Controller
    {
        private moviesEntities _db = new moviesEntities();
        //Get /Genre/Genres
        
        public ActionResult GetGenres()
        {

            var deGenres = _db.Genres.ToList();
            var vm = new GetGenresViewModel();
            vm.AlleGenres = deGenres;
            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}