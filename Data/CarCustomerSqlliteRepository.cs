namespace aspnet.Data
{
    public class CarCustomerSqlliteRepository : ICarCustomerRepository
    {
        private readonly AppDbContext _context;

        public CarCustomerSqlliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarCustomer> Cars() {
            get => _context.CarCustomers;
        }

        public bool Add(string customer)
        {
            CarCustomer temp = new CarCustomer();
            {
                Name = customer;
            };
            _context.CarCustomers.Add(temp);
            _context.SaveChanges();
            return true;
        }

        public bool Add(CarCustomer customer)
        {
            throw new NotImplementedException();
        }

        public bool Update(string customer)
        {
            var temp = _context.CarCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = customer.Name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CarCustomer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string customer)
        {
            var temp = _context.CarCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
            if (temp != null)
            {
                _context.CarCustomers.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(CarCustomer customer)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllCustomers()
        {
            return _context.CarCustomers.Select(c => c.Name).ToList();
        }
    }
}