namespace aspnet.Data
{
    public class CarReservationSqlliteRepository : ICarReservationRepository
    {
        private readonly AppDbContext _context;

        public CarReservationSqlliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarReservation> CarReservations() {
            get => _context.CarReservations;
        }

        public bool Add(string reservation)
        {
            CarReservation temp = new CarReservation();
            {
                Name = reservation;
            };
            _context.CarReservations.Add(temp);
            _context.SaveChanges();
            return true;
        }

        public bool Add(CarReservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool Update(string reservation)
        {
            var temp = _context.CarReservations.Where(r => r.Id == reservation.Id).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = reservation.Name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CarReservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string reservation)
        {
            var temp = _context.CarReservations.Where(r => r.Id == reservation.Id).FirstOrDefault();
            if (temp != null)
            {
                _context.CarReservations.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(CarReservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllReservations()
        {
            return _context.CarReservations.Select(r => r.Name).ToList();
        }
    }
}