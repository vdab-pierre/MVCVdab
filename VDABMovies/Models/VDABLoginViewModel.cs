using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VDABMovies.Models
{
    public class VDABLoginViewModel
    {
            [Required]
            [Display(Name = "Naam")]
            public string Naam { get; set; }

            [Required]
            [RegularExpression(@"^\d{4}$",ErrorMessage="Een postcode bestaat uit 4 cijfers")]
            [Display(Name = "Postcode")]
            public int Postcode { get; set; }
    }
}