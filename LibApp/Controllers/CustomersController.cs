using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        // DbContext will be polled through Dependency Injection
        public CustomersController(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        // GET: CustomersController
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = _context.Customers;
        //    return customers;
        //}

        private ApplicationDbContext _context;
    }
      
}
