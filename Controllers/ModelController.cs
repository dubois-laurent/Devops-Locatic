using aspnet.Data;
using aspnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class ModelController : Controller
    {
        private readonly ILogger<ModelController> _logger;
        private readonly ICarmodelRepository _repository;

        public ModelController(ILogger<ModelController> logger, ICarmodelRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var models = _repository.GetAllModels();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Carmodel model)
        {
            if (ModelState.IsValid)
                return View(model);
            _repository.Add(new Carmodel() { Name = model.Name, DailyPrice = model.DailyPrice, NbSeats = model.NbSeats, Fuel = model.Fuel, CarBrand = model.CarBrand });
            _logger.Log(LogLevel.Debug, model.Name + " created");

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id, Carmodel model)
        {
            if (ModelState.IsValid)
                return View(model);
            _repository.Update(model);
            _logger.Log(LogLevel.Debug, model.Name + " updated");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Carmodel model)
        {
            if (ModelState.IsValid)
                return View(model);
            _repository.Update(model);
            _logger.Log(LogLevel.Debug, model.Name + " updated");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id, Carmodel model)
        {
            if (ModelState.IsValid)
                return View(model);
            _repository.Delete(model);
            _logger.Log(LogLevel.Debug, model.Name + " deleted");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Carmodel model)
        {
            if (ModelState.IsValid)
                return View(model);
            _repository.Delete(model);
            _logger.Log(LogLevel.Debug, model.Name + " deleted");

            return RedirectToAction("Index");
        }
    }
}