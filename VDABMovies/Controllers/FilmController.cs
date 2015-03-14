using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VDABMovies.Models;
using VDABMovies.ViewModels;
using VDABMovies.ViewModels.Entities;

namespace VDABMovies.Controllers
{
    //[VDABAuthorizationFilter]
    //[HandleError]
    public class FilmController : Controller
    {
        private moviesEntities _db = new moviesEntities();

        //Get /Films/GetFilmsVanGenre/{genreNr}
        public ActionResult GetFilmsVanGenre(int GenreId)
        {
            try
            {
                var genre = _db.Genres.Find(GenreId);
                var vm = new GetFilmsVanGenreViewModel();
                vm.GekozenGenre = new GenreBuddy { Naam = genre.GenreSoort };
                vm.Films = new List<FilmBuddy>();

                Mandje mandje = new Mandje();
                if (Session["mandje"] != null)
                {
                    mandje = Session["mandje"] as Mandje;

                }

                foreach (var f in genre.Films)
                {
                    bool InHetMandje = Session["mandje"] != null && mandje.Lijnen.Where(l => l.Film.Id == f.BandNr).FirstOrDefault() != null;
                    vm.Films.Add(new FilmBuddy { Id = f.BandNr, Titel = f.Titel, Prijs = f.Prijs, InVoorraad = f.InVoorraad, InMandje = InHetMandje });
                }
                return View(vm);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        
        public ActionResult Huren(int Id)
        {
            try
            {
                Mandje mandje = new Mandje();
                MandjeLijn mandjeLijn = new MandjeLijn();

#region mandje
                if (Session["mandje"] != null)
                {
                    mandje = Session["mandje"] as Mandje;
                }
                else
                {
                    mandje.Lijnen = new List<MandjeLijn>();
                }
#endregion

#region filmtoevoegen
                var deFilm = _db.Films.Find(Id);

                if (deFilm != null && deFilm.InVoorraad > 0)
                {
                    if (mandje.Lijnen.Where(l => l.Film.Id == Id).FirstOrDefault() == null)
                    {
                        mandjeLijn.Film = new FilmBuddy { Id = deFilm.BandNr, Titel = deFilm.Titel, Prijs = deFilm.Prijs, InVoorraad = deFilm.InVoorraad };
                        mandje.Lijnen.Add(mandjeLijn);
                    }
                }
#endregion
                
                Session["mandje"] = mandje;

                if (mandje.Lijnen.Count > 0)
                {
                    return RedirectToAction("WinkelMandje", "Winkel");
                }
                else {
                    return RedirectToAction("GetGenres", "Genre");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
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