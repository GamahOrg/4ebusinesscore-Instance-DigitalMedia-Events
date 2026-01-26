using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain.Models
{
    public class Events : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? MainImageUrl { get; set; }
        public string? VideoEventUrl { get; set; }
        public Guid? SectorId { get; set; }
        public Sector Sector { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? LocationDetails { get; set; }
        public string? UrlLocation { get; set; }
        public string? RegisterationUrl { get; set; }
        public string TargetGroup { get; set; }
        public bool IsFree { get; set; }
        public decimal? Cost { get; set; }
        //[ForeignKey("EventsStatus")]
        //public LK_EventsStatus LK_EventsStatus { get; set; }
        public EventsStatus EventsStatus { get; set; }
        public virtual ICollection<EventsView> Views { get; set; }
        public virtual ICollection<EventAgenda>? EventAgenda { get; set; }
        public virtual ICollection<EventsAttachments>? EventsAttachments { get; set; }
        public virtual ICollection<EventsComment> EventsComments { get; set; }
        public virtual ICollection<EventsRate> EventsRates { get; set; }
    }
}
