using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        ApplicationDbContext _context;
        IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            var moviesDto =  _context.Movies.Select(_mapper.Map<Movie, MovieDto>);
            if (!moviesDto.Any())
                return NotFound();
            

            return moviesDto.ToList();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movieInDB = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
            if(movieInDB == null)            
                return NotFound();            

          return  _mapper.Map<Movie, MovieDto>(movieInDB);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(MovieDto movieDto)
        {
            Movie movie = new Movie();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);

            await _context.SaveChangesAsync();
            movieDto.Id = movie.Id;

            

            return Ok(movieDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id, MovieDto movieDto)
        {
            if(!ModelState.IsValid) return BadRequest();

            var movieInDb = await _context.Movies.SingleOrDefaultAsync(x=> x.Id == id);

            movieInDb = _mapper.Map<MovieDto,Movie>(movieDto);

            //_context.Entry(movieInDb).State = EntityState.Modified;
            _context.Update(movieInDb);

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


            return Ok(movieDto);

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movie= _context.Movies.SingleOrDefault(x=> x.Id == id);

            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }


        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }


    }
}
