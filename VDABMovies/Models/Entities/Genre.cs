//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VDABMovies.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Genre
    {
        public Genre()
        {
            this.Films = new HashSet<Film>();
        }
    
        public int GenreNr { get; set; }
        public string GenreSoort { get; set; }
    
        public virtual ICollection<Film> Films { get; set; }
    }
}
