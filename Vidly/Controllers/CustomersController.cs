using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private static List<MembershipTypeViewModel> _membershipTypes;


        public CustomersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _membershipTypes = _membershipTypes ??
                               dbContext.MembershipTypes.ProjectTo<MembershipTypeViewModel>().ToList();
        }


        // GET
        public  IActionResult Index()
        {
            var customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
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
            var newCustomerViewModel = Mapper.Map<CustomerFormViewModel>(_membershipTypes);

            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CustomerFormViewModel customerFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                Mapper.Map(_membershipTypes, customerFormViewModel);
                return View("CustomerForm", customerFormViewModel);
            }
            
            if (customerFormViewModel.Id == 0)
            {
                var customer = Mapper.Map<Customer>(customerFormViewModel);
                
                // new customer
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var cust = _dbContext.Customers.Single(c => c.Id == customerFormViewModel.Id);
                Mapper.Map(customerFormViewModel, cust);
            }
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.Include(c=> c.MembershipType).SingleOrDefault(c=>c.Id==id);
                
            if (customer == null) return NotFound();

            var vm = Mapper.Map(_membershipTypes, Mapper.Map<CustomerFormViewModel>(customer));
            
            
            return View("CustomerForm", vm);

        }

        
    }
}