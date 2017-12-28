using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Vidly.Models;
using Vidly.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var vm = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = new List<Customer>()
                {
                    new Customer() {Name = "Customer 1"},
                    new Customer() {Name = "Customer 2"}
                }
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
