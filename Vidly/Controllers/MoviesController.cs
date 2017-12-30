using GenFu;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using WebEssentials.AspNetCore.Pwa;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly WebManifest _webManifest;

        public MoviesController(WebManifest webManifest)
        {
            _webManifest = webManifest;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {

            ViewBag.SiteName = _webManifest.Name;
            ViewBag.Description = _webManifest.Description;
            
            var movies = A.ListOf<Movie>(5);
            var vm = new RandomMovieViewModel()
            {
                Movies = movies,
                Customers = A.ListOf<Customer>(5)
            };
            return View(vm);
        }
        
    }
}
