using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Vidly.Models;
using Vidly.Persistance;
using Vidly.ViewModels;
using WebEssentials.AspNetCore.Pwa;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly WebManifest _webManifest;
        private readonly ApplicationDbContext _applicationDbContext;
        private static List<Genre> _genres;

        public MoviesController(ApplicationDbContext applicationDbContext)
        {
            //_webManifest = webManifest;
            _applicationDbContext = applicationDbContext;
            _genres = _genres ?? _applicationDbContext.Genres.ToList();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
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
        public IActionResult Save(MoviesFormViewModel moviesFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                moviesFormViewModel.Genres = _genres;
                return View("MoviesForm", moviesFormViewModel);
            }
            
            
            if (moviesFormViewModel.Id == 0)
            {
                // new movie
                _applicationDbContext.Movies.Add(Mapper.Map<Movie>(moviesFormViewModel));
            }
            else
            {
                var movieinDb = _applicationDbContext.Movies.SingleOrDefault(m => m.Id == moviesFormViewModel.Id);
                Mapper.Map(moviesFormViewModel, movieinDb);
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

            var vm = Mapper.Map<MoviesFormViewModel>(movie);
            vm.Genres = _genres;

            return View("MoviesForm", vm);
        }
    }
}
