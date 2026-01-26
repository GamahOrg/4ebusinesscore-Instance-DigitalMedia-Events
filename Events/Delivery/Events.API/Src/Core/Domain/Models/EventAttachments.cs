namespace Events.Domain.Models
{
    public class EventsAttachments : BaseEntity<Guid>
    {
        public Guid EventsId { get; set; }
        public Events Events { get; set; }
        public string ImagePath { get; set; }

    }
}
