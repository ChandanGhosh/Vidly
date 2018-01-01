using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
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
        
        public Genre Genre { get; set; }
        
        
    }
}
