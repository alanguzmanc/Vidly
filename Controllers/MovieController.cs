using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();


            return View(movies);
        }

        public IActionResult Details(int Id)
        {
           var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)            
                return NotFound();

            var viewModel = new MovieFormViewModel(movie, _context.Genres.ToList());       

            return View(viewModel);
        }

        public IActionResult ViewForm(int Id) 
        {
            var viewModel = new MovieFormViewModel();
            var genres = _context.Genres.ToList();

            if (Id == 0)
                viewModel = new MovieFormViewModel(new Movie(), genres);

            else
                viewModel = new MovieFormViewModel(_context.Movies.Single(m => m.Id == Id), genres);
                    
                                
            

            return View("ViewForm", viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(MovieFormViewModel model)
        {
            var viewModel = new MovieFormViewModel();

            var movie = new Movie()
            {
                Id = model.Id.GetValueOrDefault(),
                Name = model.Name,
                GenreId = model.GenreId.GetValueOrDefault(),
                ReleaseDate = model.ReleaseDate.GetValueOrDefault(),
                NumberInStock = model.NumberInStock.GetValueOrDefault()
            };

            if (!ModelState.IsValid)
            {
                viewModel = new MovieFormViewModel(movie, _context.Genres.OrderBy(g => g.Name).ToList());                
                return View("ViewForm", viewModel);
            }
           

            if (model.Id == 0)
            {
                //model.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == model.Id);
                existingMovie.Name = model.Name;
                existingMovie.NumberInStock = model.NumberInStock.GetValueOrDefault();
                existingMovie.GenreId = model.GenreId.GetValueOrDefault();
                existingMovie.ReleaseDate = model.ReleaseDate.GetValueOrDefault();
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
