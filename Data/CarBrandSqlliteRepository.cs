namespace aspnet.Data
{
    public class CarBrandSqlliteRepository : ICarBrandRepository
    {
        private readonly AppDbContext _context;

        public CarBrandSqlliteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CarBrand> Brands() {
            get => _context.CarBrands;
        }

        public bool Add(string brand)
        {
            CarBrand temp = new CarBrand();
            {
                Name = brand;
            };
            _context.CarBrands.Add(temp);
            _context.SaveChanges();
            return true;
        }

        public bool Add(CarBrand brand)
        {
            throw new NotImplementedException();
        }

        public bool Update(string brand)
        {
            var temp = _context.CarBrands.Where(b => b.Id == brand.Id).FirstOrDefault();
            if (temp != null)
            {
                temp.Name = brand.Name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(CarBrand brand)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string brand)
        {
            var temp = _context.CarBrands.Where(b => b.Id == brand.Id).FirstOrDefault();
            if (temp != null)
            {
                _context.CarBrands.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(CarBrand brand)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllBrands()
        {
            return _context.CarBrands.Select(b => b.Name).ToList();
        }
    }
}