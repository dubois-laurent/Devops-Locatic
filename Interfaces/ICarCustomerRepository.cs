namespace aspnet.Data
{
    public interface ICarCustomerRepository
    {
        public IEnumerable<Carcustomer> Customers { get; }
        public bool Add(Carcustomer customer);
        public bool Update(Carcustomer customer);
        public bool Delete(Carcustomer customer);
        public List<string> GetAllCustomers();
    }
}