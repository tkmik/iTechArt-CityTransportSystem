namespace DataAccess.Entities
{
    public class TransportTypeStop
    {
        public int Id { get; set; }

        public int TransportTypeId { get; set; }
        public virtual TransportType TransportType { get; set; }

        public int StopId { get; set; }
        public virtual Stop Stop { get; set; }
    }
}
