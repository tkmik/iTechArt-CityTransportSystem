namespace DataAccess.Entities
{
    public class TripTransport
    {
        public int Id { get; set; }

        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        public int TransportId { get; set; }
        public virtual Transport Transport { get; set; }
    }
}
