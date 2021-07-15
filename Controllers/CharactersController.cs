using Aceleracion.Contexts;
using Aceleracion.Dto.Character;
using Aceleracion.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aceleracion.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DisneyContext _context;

        public CharactersController(DisneyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()       
        {            
            var listCharacters = await _context.Characters.ToListAsync();
            var listDto = new List<CharacterResponseDto>();

            foreach (var l in listCharacters)
            {
                var dto = new CharacterResponseDto
                {
                    Image = l.Image,
                    Name = l.Name
                };
                listDto.Add(dto);
            }
            return Ok(listDto);           
        }

        [HttpGet]
        [Route("/Characters/Details")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharactersDetails(string name, int age, int idMovie)
        {
            var list = new List<Character>();

            if (name == null & age == 0 & idMovie == 0)
            {
                list = await _context.Characters.Include(x => x.Movies).ToListAsync();
            }
            else if (name != null & age == 0 & idMovie == 0)
            {
                list = await _context.Characters.Include(x => x.Movies).Where(c => c.Name == name).ToListAsync();
            }
            else if (name == null & age != 0 & idMovie == 0)
            {
                list = await _context.Characters.Include(x => x.Movies).Where(c => c.Age == age).ToListAsync();
            }
            else if (name == null & age == 0 & idMovie != 0)
            {                
                list = await _context.Characters.Include(z => z.Movies).Select(x => new Character
                {
                    CharacterId = x.CharacterId,
                    Image = x.Image,
                    Name = x.Name,
                    Age = x.Age,
                    Weight = x.Weight,
                    History = x.History,
                    Movies = x.Movies
                    .Where(p => p.MovieId == idMovie).ToList()
                }).Where(v => v.Movies.FirstOrDefault(n => n.MovieId == idMovie)!= null).ToListAsync();                
            }
           
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterRequestDto character)
        {
            var previous = await _context.Characters.FirstOrDefaultAsync(x => x.Name == character.Name);

            if (previous != null)
            {
                return BadRequest($"The {character.Name} character alredy exits");
            }
            var charEntity = new Character
            {
                Image = character.Image,
                Name = character.Name,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History
            };

            if (character.MovieId.GetValueOrDefault() != 0)
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == character.MovieId.Value);

                if (movie != null)
                {
                    charEntity.Movies.Add(movie);
                }
            }

            await _context.Characters.AddAsync(charEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterRequestDto character)
        {
            var charEntity = new Character
            {
                CharacterId = id,
                Image = character.Image,
                Name = character.Name,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History
            };

            if (id != charEntity.CharacterId)
            {
                return BadRequest();
            }

            _context.Entry(charEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
