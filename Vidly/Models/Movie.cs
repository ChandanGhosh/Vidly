using System;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime ReleasedDate { get; set; }
        public int Stock { get; set; }

        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        
    }
}
