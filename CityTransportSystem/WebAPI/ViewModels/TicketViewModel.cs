namespace WebAPI.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public float Cost { get; set; }

        public int TripValidationId { get; set; }
        public TripValidationViewModel TripValidation { get; set; }
    }
}
