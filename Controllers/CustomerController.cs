using aspnet.Data;
using aspnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _repository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var customers = _repository.GetAllCustomers();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
                return View(customer);
            _repository.Add(new Customer() { Name = customer.Name, Email = customer.Email, Phone = customer.Phone });
            _logger.Log(LogLevel.Debug, customer.Name + " created");

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id, Customer customer)
        {
            if (ModelState.IsValid)
                return View(customer);
            _repository.Update(customer);
            _logger.Log(LogLevel.Debug, customer.Name + " updated");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
                return View(customer);
            _repository.Update(customer);
            _logger.Log(LogLevel.Debug, customer.Name + " updated");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = _repository.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            _repository.Delete(customer);
            _logger.Log(LogLevel.Debug, customer.Name + " deleted");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brand = _repository.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null)
                return NotFound();

            _repository.Delete(brand);
            _logger.Log(LogLevel.Debug, brand.Name + " deleted");

            return RedirectToAction("Index");
        }
    }
}