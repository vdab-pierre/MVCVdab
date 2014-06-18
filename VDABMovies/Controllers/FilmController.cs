using System;
using System.Collections.Generic;
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
        public ActionResult GetFilmsVanGenre(int Id)
        {
            var genre = _db.Genres.Find(Id);
            var vm = new GetFilmsVanGenreViewModel();
            vm.GekozenGenre = new GenreBuddy { Naam = genre.GenreSoort };
            vm.Films = new List<FilmBuddy>();

            foreach (var f in genre.Films)
            {
                vm.Films.Add(new FilmBuddy { Id = f.BandNr, Titel = f.Titel, Prijs = f.Prijs, InVoorraad = f.InVoorraad });
            }
            return View(vm);
        }

        [HandleError]
        public ActionResult Huren(int Id)
        {
            try
            {
                //enkel film toevoegen aan mandje indien nog niet in mandje
                var deFilm = _db.Films.Find(Id);
                MandjeLijn mandjeLijn = new MandjeLijn();
                mandjeLijn.Film = new FilmBuddy { Id = deFilm.BandNr, Titel = deFilm.Titel, Prijs = deFilm.Prijs, InVoorr aad = deFilm.InVoorraad };
                Mandje mandje = new Mandje();
                if (Session["mandje"] != null)
                {
                    mandje = Session["mandje"] as Mandje;
                    mandje.Lijnen.Add(mandjeLijn);
                }
                else
                {
                    mandje.Lijnen = new List<MandjeLijn>();
                    mandje.Lijnen.Add(mandjeLijn);
                }
                Session["mandje"] = mandje;

                return RedirectToAction("WinkelMandje", "Winkel");
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