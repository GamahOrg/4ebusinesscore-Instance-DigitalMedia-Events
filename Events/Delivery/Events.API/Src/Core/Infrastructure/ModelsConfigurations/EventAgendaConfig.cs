namespace Events.Infrastructure.ModelsConfigurations
{
    public class EventAgendaConfig : IEntityTypeConfiguration<EventAgenda>
    {
        public void Configure(EntityTypeBuilder<EventAgenda> builder)
        {
            builder.HasMany(a => a.timePeriods)
                    .WithOne(a => a.EventAgenda)
                    .HasForeignKey(a => a.EventAgendaId);



        }
    }
}
