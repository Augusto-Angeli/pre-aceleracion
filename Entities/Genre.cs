using System.Collections.Generic;

namespace Aceleracion.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
