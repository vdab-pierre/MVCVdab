﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDABMovies.Models;
using VDABMovies.Models.Entities;

namespace VDABMovies.Controllers
{
    [VDABAuthorizationFilter]
    public class WinkelController : Controller
    {
        // GET: Winkel
        public ActionResult WinkelMandje()
        {
            Mandje mandje = null;
            if (Session["mandje"] != null)
            {
                mandje = Session["mandje"] as Mandje;
            }
            MandjeViewModel vm = new MandjeViewModel();
            vm.WinkelMandje = mandje;
            return View(vm);
        }

        [HttpGet]
        public ActionResult FilmVerwijderenUitMandje(int Id) {

            if (Session["mandje"] != null)
            {
                Mandje mandje = null;
                mandje = Session["mandje"] as Mandje;
                var deLijn = mandje.Lijnen.Where(l => l.Film.Id == Id).FirstOrDefault();
                if (deLijn != null)
                {
                    FilmVerwijderenViewModel vm = new FilmVerwijderenViewModel { TeVerwijderenFilm = new FilmBuddy { Id = deLijn.Film.Id, Titel = deLijn.Film.Titel, Prijs = deLijn.Film.Prijs, InVoorraad = deLijn.Film.InVoorraad } };
                    return View(vm);
                }
                else {
                    return View("Error");
                }
            }
            else {
                return View("Error");
            }
                        
        }
        [ActionName("FilmVerwijderenUitMandje")]
        [HttpPost]
        public ActionResult PostFilmVerwijderenUitMandje(int Id)
        {
            Mandje mandje = null;
            if (Session["mandje"] != null)
            {
                mandje = Session["mandje"] as Mandje;
                var reedsInMandje = mandje.Lijnen.Where(l => l.Film.Id == Id).FirstOrDefault();
                if (reedsInMandje != null)
                {

                    mandje.Lijnen.Remove(reedsInMandje);
                    Session["mandje"] = mandje;
                    MandjeViewModel vm = new MandjeViewModel();
                    vm.WinkelMandje = mandje;
                    return View("WinkelMandje", vm);
                }

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Afrekenen() {
            Mandje mandje = null;
            Klant deKlant = null;
            if (Session["mandje"] != null)
            {
                mandje = Session["mandje"] as Mandje;
            }
            if (Session["login"] != null)
            {
                deKlant = Session["login"] as Klant;
            }


            //db aanpassen!
            //inVoorraad wordt met 1 verminderd en UitVoorraad met 1 vermeerderd

            

            var vm = new AfrekenenViewModel { Klant = deKlant, Winkelmandje = mandje };
            return View(vm);
        }
    }
}