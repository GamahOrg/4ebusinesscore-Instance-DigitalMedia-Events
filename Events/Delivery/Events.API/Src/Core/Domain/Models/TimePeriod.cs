namespace Events.Domain.Models
{
    public class TimePeriod : BaseEntity<Guid>
    {
        public Guid EventAgendaId { get; set; }
        public EventAgenda EventAgenda { get; set; }
        public DateTime StartTime { get; set; }
        public string Details { get; set; }
        public DateTime EndTime { get; set; }
    }
}
