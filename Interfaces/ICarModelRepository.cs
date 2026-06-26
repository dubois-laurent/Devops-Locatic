namespace aspnet.Data
{
    public interface ICarModelRepository
    {
        public IEnumerable<Carmodel> Models { get; }
        public bool Add(Carmodel model);
        public bool Update(Carmodel model);
        public bool Delete(Carmodel model);
        public List<string> GetAllModels();
    }
}