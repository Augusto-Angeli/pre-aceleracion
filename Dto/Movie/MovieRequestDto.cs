using System;
using System.ComponentModel.DataAnnotations;

namespace Aceleracion.Dto.Movie
{
    public class MovieRequestDto
    {      
        public string Image { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }

        public int? GenreId { get; set; }
        public int? CharacterId { get; set; }
    }
}
