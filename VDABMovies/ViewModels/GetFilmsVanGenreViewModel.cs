using System.Collections.Generic;
using VDABMovies.Models;

namespace VDABMovies.ViewModels
{
    public class GetFilmsVanGenreViewModel
    {
        public List<FilmBuddy> Films { get; set; }
        public GenreBuddy GekozenGenre { get; set; }
    }
}