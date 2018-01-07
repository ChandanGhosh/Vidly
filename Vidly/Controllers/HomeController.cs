using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Vidly.Configurations;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationSettings _configuration;


        public HomeController(ApplicationSettings configuration)
        {
            
            _configuration = configuration;

            
        }
        
        public IActionResult Index()
        {
            ViewBag.AppName = _configuration.AppName;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
