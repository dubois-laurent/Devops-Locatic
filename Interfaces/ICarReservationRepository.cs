namespace aspnet.Data
{
    public interface ICarReservationRepository
    {
        public IEnumerable<Carreservation> Reservations { get; }
        public bool Add(Carreservation reservation);
        public bool Update(Carreservation reservation);
        public bool Delete(Carreservation reservation);
        public List<string> GetAllReservations();
    }
}