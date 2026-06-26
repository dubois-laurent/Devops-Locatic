namespace aspnet.Data
{
    public class CarModelSqlliteRepository : ICarModelRepository
    {
        private readonly AppDbContext _context;

        public CarModelSqlliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarModel> Models() {
            get => _context.CarModels;
        }

        public bool Add(string model)
        {
            CarModel temp = new CarModel();
            {
                Name = model;
            };
            _context.CarModels.Add(temp);
            _context.SaveChanges();
            return true;
        }

        public bool Add(CarModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(string model)
        {
            var temp = _context.CarModels.Where(m => m.Id == model.Id).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = model.Name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CarModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string model)
        {
            var temp = _context.CarModels.Where(m => m.Id == model.Id).FirstOrDefault();
            if (temp != null)
            {
                _context.CarModels.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(CarModel model)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllModels()
        {
            return _context.CarModels.Select(m => m.Name).ToList();
        }
    }
}