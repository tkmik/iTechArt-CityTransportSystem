namespace BusinessLogic.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public float Cost { get; set; }

        public int TripValidationId { get; set; }
        public TripValidationDto TripValidation { get; set; }
    }
}
