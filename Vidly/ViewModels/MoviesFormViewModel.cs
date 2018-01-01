using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesFormViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime Created { get; set; } = DateTime.Now;
        
        [Required]
        public DateTime ReleasedDate { get; set; }
        
        [Required]
        public int Stock { get; set; }

        public byte GenreId { get; set; }
        
        
        public IEnumerable<Genre> Genres = new List<Genre>();
        
        
        
    }
}
