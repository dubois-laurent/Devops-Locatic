namespace aspnet.Data
{
    public interface ICarbrandRepository
    {
        public IEnumerable<Carbrand> Brands { get; }
        public bool Add(Carbrand brand);
        public bool Update(Carbrand brand);
        public bool Delete(Carbrand brand);
        public List<string> GetAllBrands();
    }
}