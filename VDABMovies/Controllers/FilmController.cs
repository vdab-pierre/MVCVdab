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
        public ActionResult GetFilmsVanGenre(int Id)
        {
            try
            {
                var genre = _db.Genres.Find(Id);
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
                
                if (Session["mandje"] != null)
                {
                    mandje = Session["mandje"] as Mandje;
                    if(mandje.Lijnen.Where(l => l.Film.Id == Id).FirstOrDefault()==null){
                        var deFilm = _db.Films.Find(Id);
                        mandjeLijn.Film = new FilmBuddy { Id = deFilm.BandNr, Titel = deFilm.Titel, Prijs = deFilm.Prijs, InVoorraad = deFilm.InVoorraad };
                        mandje.Lijnen.Add(mandjeLijn);
                    }
                }
                else
                {
                    mandje.Lijnen = new List<MandjeLijn>();
                    var deFilm = _db.Films.Find(Id);
                    mandjeLijn.Film = new FilmBuddy { Id = deFilm.BandNr, Titel = deFilm.Titel, Prijs = deFilm.Prijs, InVoorraad = deFilm.InVoorraad };
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