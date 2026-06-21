using aspnet.Interfaces;
using aspnet.Models;

namespace aspnet.Data
{
    public class CarSqlliteRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarSqlliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> Cars() {
            get => _context.Cars;
        }

        public bool Add(string car)
        {
            Car temp = new Car();
            {
                Name = car;
            };
            _context.Cars.Add(temp);
            _context.SaveChanges();
            return true;
        }

        public bool Add(Car car)
        {
            throw new NotImplementedException();
        }

        public bool Update(string car)
        {
            var temp = _context.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = car.Name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Car car)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string car)
        {
            var temp = _context.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
            if (temp != null)
            {
                _context.Cars.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllBrands()
        {
            return _context.CarBrands.Select(b => b.Name).ToList();
        }
    }
}