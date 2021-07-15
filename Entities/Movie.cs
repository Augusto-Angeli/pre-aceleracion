using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aceleracion.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Range(1,5)]
        public int Qualification { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genres { get; set; } 
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
