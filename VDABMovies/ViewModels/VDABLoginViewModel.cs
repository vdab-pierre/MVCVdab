using System.ComponentModel.DataAnnotations;

namespace VDABMovies.ViewModels
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