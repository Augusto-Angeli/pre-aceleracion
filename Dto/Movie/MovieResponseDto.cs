using System;
using System.ComponentModel.DataAnnotations;

namespace Aceleracion.Dto.Movie
{
    public class MovieResponseDto
    {        
        public string Image { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
