using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Antiforgery.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;
using Vidly.Persistance;
using Vidly.ViewModels;

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
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                // new customer
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var cust = _dbContext.Customers.Single(c => c.Id == customer.Id);
                Mapper.Map(customer, cust);
                
            }
            
            
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            var vm = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", vm);

        }

        
    }
}