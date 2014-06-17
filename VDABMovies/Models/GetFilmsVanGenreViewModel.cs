using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VDABMovies.Models.Entities;

namespace VDABMovies.Models
{
    public class GetFilmsVanGenreViewModel
    {
        public List<FilmBuddy> Films { get; set; }
        public GenreBuddy GekozenGenre { get; set; }
    }
}