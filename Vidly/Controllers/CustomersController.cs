using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private static List<Customer> _customers;

        // GET
        public IActionResult Index()
        {
            _customers = GenFu.GenFu.ListOf<Customer>(4);
            
            
            return
            View(_customers);
        }

        [Route("Customers/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            if (_customers.All(c => c.Id != id))
            {
                return NotFound();
            }
            
            return View(_customers.First(c => c.Id == id));
        }
    }
}