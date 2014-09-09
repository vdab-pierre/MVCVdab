using System.Collections.Generic;
using System.Web.Mvc;
using VDABMovies.Models.Entities;

namespace VDABMovies.ViewModels
{
    public class GetGenresViewModel
    {
        public List<Genre> AlleGenres { get; set; }

        public int GenreId { get; set; }
        public IEnumerable<SelectListItem> DeGenres { get; set; }
    }
}