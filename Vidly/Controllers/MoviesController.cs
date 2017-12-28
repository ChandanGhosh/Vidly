using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public IActionResult Random()
        {

            ViewBag.SiteName = _webManifest.Name;
            ViewBag.Description = _webManifest.Description;
            
            var movie = A.New<Movie>();
            var vm = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = A.ListOf<Customer>(5)
            };
            return View(vm);
        }
        [Route("Movies/Released/{year:maxlength(4)}/{month:maxlength(2):min(1):max(12)}")]
        public IActionResult Released(int year, int month)
        {
            return Content("Released year=" + year + "and month=" + month);
        }
    }
}
