using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.Persistance;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private static List<Customer> _customers;

        public CustomersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET
        public IActionResult Index()
        {
            _customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return
                View(_customers);
        }

        [Route("Customers/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
    }
}