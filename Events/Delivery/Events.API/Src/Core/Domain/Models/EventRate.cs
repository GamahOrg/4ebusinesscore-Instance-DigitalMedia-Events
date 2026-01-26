namespace Events.Domain.Models
{
    public class EventsRate : BaseEntity<Guid>
    {

        public Guid EventsId { get; set; }
        public Events Events { get; set; }
        public int RateValue { get; set; }
        public string? Comment { get; set; }

    }
}
