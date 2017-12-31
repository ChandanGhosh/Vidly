using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.Persistance;
using Vidly.ViewModels;
using WebEssentials.AspNetCore.Pwa;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly WebManifest _webManifest;
        private readonly ApplicationDbContext _applicationDbContext;

        public MoviesController(WebManifest webManifest, ApplicationDbContext applicationDbContext)
        {
            _webManifest = webManifest;
            _applicationDbContext = applicationDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.SiteName = _webManifest.Name;
            ViewBag.Description = _webManifest.Description;

            var movies = _applicationDbContext.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        [Route("Movies/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var movie = _applicationDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                // new movie
                _applicationDbContext.Movies.Add(movie);
            }
            else
            {
                var movieinDb = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == movie.Id);
                Mapper.Map(movie, movieinDb);
            }

            _applicationDbContext.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult New()
        {
            ViewBag.Title = "New Movie";
            
            var vm = new MoviesFormViewModel()
            {
                Genres = _applicationDbContext.Genres.ToList()
            };
            
            return View("MoviesForm", vm);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Movie";
            var movie = _applicationDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            var vm = new MoviesFormViewModel()
            {
                Genres = _applicationDbContext.Genres.ToList(),
                Movie = movie
            };

            return View("MoviesForm", vm);
        }
    }
}
