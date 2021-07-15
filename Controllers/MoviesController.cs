using Aceleracion.Contexts;
using Aceleracion.Dto.Movie;
using Aceleracion.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aceleracion.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DisneyContext _context;

        public MoviesController(DisneyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string name, int genre)
        {
            var list = new List<Movie>();
            var listMovies = await _context.Movies.ToListAsync();
            var listDto = new List<MovieResponseDto>();

            if (name != null)
            {
                list = await _context.Movies.Include(x => x.Characters).Where(c => c.Title == name).ToListAsync();
                return Ok(list);
            }
            else if (genre != 0)
            {
                list = await _context.Movies.Include(z => z.Genres).Where(x => x.GenreId == genre).ToListAsync();
                return Ok(list);
            }
            else
            {
                foreach (var l in listMovies)
                {
                    var dto = new MovieResponseDto
                    {
                        Image = l.Image,
                        Title = l.Title,
                        CreationDate = l.CreationDate
                    };
                    listDto.Add(dto);
                }

            }
            return Ok(listDto);
        }

        [Route("/Details")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Character>>> GetMoviesDetails()
        {
            var list = new List<Movie>();
            
            list = await _context.Movies.Include(x => x.Characters).ToListAsync();
            
            return Ok(list);
        }


        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieRequestDto movie)
        {
            var previous = await _context.Movies.FirstOrDefaultAsync(x => x.Title == movie.Title);

            if (previous != null)
            {
                return BadRequest();
            }
            var movieEntity = new Movie
            {
                Image = movie.Image,
                Title = movie.Title,
                CreationDate = movie.CreationDate,
                Qualification = movie.Qualification,
                GenreId = (int)movie.GenreId
            };

            if (movie.GenreId.GetValueOrDefault() != 0)
            {
                var genre = await _context.Genres.FirstOrDefaultAsync(x => x.GenreId == movie.GenreId.Value);
            }
            if (movie.CharacterId.GetValueOrDefault() != 0)
            {
                var character = await _context.Characters.FirstOrDefaultAsync(x => x.CharacterId == movie.CharacterId.Value);

                if (character != null)
                {
                    movieEntity.Characters.Add(character);
                }
            }
                        
            await _context.Movies.AddAsync(movieEntity);           
            await _context.SaveChangesAsync();

            return Ok("Successful");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieRequestDto movie)
        {
            var movieEntity = new Movie
            {
                MovieId = id,
                Image = movie.Image,
                Title = movie.Title,
                CreationDate = movie.CreationDate,
                Qualification = movie.Qualification,
                 GenreId = (int)movie.GenreId
            };

            if (id != movieEntity.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
