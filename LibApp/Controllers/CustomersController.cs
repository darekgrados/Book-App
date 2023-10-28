using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: CustomersController
        public ViewResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("User not found");
            }

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Jan Kowalski" },
                new Customer { Id = 2, Name = "Monika Nowak" }
            };
        }
    }
      
}
