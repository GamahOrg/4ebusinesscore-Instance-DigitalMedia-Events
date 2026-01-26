
namespace Events.Domain.Models
{
    public class EventsComment : BaseEntity<Guid>
    {
        public string Description { get; set; }

        public Guid EventsId { get; set; }
        public Events Events { get; set; }


    }
}
