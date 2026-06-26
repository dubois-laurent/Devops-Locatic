using aspnet.Interfaces;
using aspnet.Models;
using aspnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _repository;
        private List<Car> _cars
        {
            get
            {
                return _repository.GetAllCars();
            }
        }

        public CarController(ILogger<CarController> logger, ICarRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var cars = _repository.GetAllCars();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
                return View(car);
            _repository.Add(new Car() { Name = car.Name, BrandId = car.BrandId, PricePerDay = car.PricePerDay });
            _logger.Log(LogLevel.Debug, car.Name + " created");

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id, Car car)
        {
            if (ModelState.IsValid)
                return View(car);
            _repository.Update(car);
            _logger.Log(LogLevel.Debug, car.Name + " updated");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid)
                return View(car);
            _repository.Update(car);
            _logger.Log(LogLevel.Debug, car.Name + " updated");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id, Car car)
        {
            if (ModelState.IsValid)
                return View(car);
            _repository.Delete(car);
            _logger.Log(LogLevel.Debug, car.Name + " deleted");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id, Car car)
        {
            if (ModelState.IsValid)
                return View(car);
            _repository.Delete(car);
            _logger.Log(LogLevel.Debug, car.Name + " deleted");

            return RedirectToAction("Index");
        }
    }
}