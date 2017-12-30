using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Persistance;
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
    }
}
