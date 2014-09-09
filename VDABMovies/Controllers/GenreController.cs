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
        

        private IEnumerable<SelectListItem> HaalGenres() {
            var genres = _db.Genres
                .Select(x => new SelectListItem
                {
                    Value = x.GenreNr.ToString(),
                    Text = x.GenreSoort
                });
            return new SelectList(genres, "Value", "Text");
        }
        
        //Get /Genre/Genres
        public ActionResult GetGenres()
        {

            var deGenres = _db.Genres.ToList();
            var vm = new GetGenresViewModel { 
                AlleGenres=deGenres,
                DeGenres=HaalGenres()
            };
            
            
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