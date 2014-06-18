using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDABMovies.Models
{
    public class FilmBuddy
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        [DisplayFormat(DataFormatString="{0:C}")]
        public decimal Prijs { get; set; }
        public int InVoorraad { get; set; }
        public bool InMandje { get; set; }
    }
}