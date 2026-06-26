using aspnet.Data;
using aspnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;
        private readonly ICarbrandRepository _repository;

        public BrandController(ILogger<BrandController> logger, ICarbrandRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var brands = _repository.GetAllBrands();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Carbrand brand)
        {
            if (ModelState.IsValid)
                return View(brand);
            _repository.Add(new CarBrand() { Name = brand.Name });
            _logger.Log(LogLevel.Debug, brand.Name + " created");

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id, Carbrand brand)
        {
            if (ModelState.IsValid)
                return View(brand);
            _repository.Update(brand);
            _logger.Log(LogLevel.Debug, brand.Name + " updated");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Carbrand brand)
        {
            if (ModelState.IsValid)
                return View(brand);
            _repository.Update(brand);
            _logger.Log(LogLevel.Debug, brand.Name + " updated");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var brand = _repository.Brands.FirstOrDefault(b => b.Id == id);
            if (brand == null)
                return NotFound();

            _repository.Delete(brand);
            _logger.Log(LogLevel.Debug, brand.Name + " deleted");

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