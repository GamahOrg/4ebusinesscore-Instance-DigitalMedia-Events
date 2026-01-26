
namespace Events.Domain.Models
{
    public class EventsView : BaseEntity<Guid>
    {
        public Guid EventsId { get; set; }
        public Events Events { get; set; }
    }
}
