using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDABMovies.Models;

namespace VDABMovies.Controllers
{
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

        public ActionResult FilmVerwijderenUitMandje(int Id)
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
    }
}