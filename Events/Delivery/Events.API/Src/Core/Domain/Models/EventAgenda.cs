namespace Events.Domain.Models
{
    public class EventAgenda : BaseEntity<Guid>
    {
        public Guid EventsId { get; set; }
        public Events Events { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TimePeriod> timePeriods { get; set; }

    }
}
