namespace DataAccess.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public float Cost { get; set; }

        public int TripValidationId { get; set; }
        public virtual TripValidation TripValidation { get; set; }
    }
}
