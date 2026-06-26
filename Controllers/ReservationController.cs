using aspnet.Data;
using aspnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly ICarReservationRepository _repository;

        public ReservationController(ILogger<ReservationController> logger, ICarReservationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var reservations = _repository.GetAllReservations();
            return View(reservations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarReservation reservation)
        {
            if (ModelState.IsValid)
                return View(reservation);
            _repository.Add(new CarReservation() { CustomerId = reservation.CustomerId, CarId = reservation.CarId, StartDate = reservation.StartDate, EndDate = reservation.EndDate });
            _logger.Log(LogLevel.Debug, reservation.CustomerId + " created");

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id, CarReservation reservation)
        {
            if (ModelState.IsValid)
                return View(reservation);
            _repository.Update(reservation);
            _logger.Log(LogLevel.Debug, reservation.CustomerId + " updated");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(CarReservation reservation)
        {
            if (ModelState.IsValid)
                return View(reservation);
            _repository.Update(reservation);
            _logger.Log(LogLevel.Debug, reservation.CustomerId + " updated");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var reservation = _repository.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
                return NotFound();

            _repository.Delete(reservation);
            _logger.Log(LogLevel.Debug, reservation.CustomerId + " deleted");

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