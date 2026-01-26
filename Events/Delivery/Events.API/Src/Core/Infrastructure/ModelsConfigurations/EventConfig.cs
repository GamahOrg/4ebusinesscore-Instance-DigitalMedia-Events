namespace Events.Infrastructure.ModelsConfigurations
{
    public class EventsConfig : IEntityTypeConfiguration<EventsModel>
    {
        public void Configure(EntityTypeBuilder<EventsModel> builder)
        {
            builder.HasMany(a => a.EventsRates)
                    .WithOne(a => a.Events)
                    .HasForeignKey(a => a.EventsId);

            builder.HasMany(a => a.EventsAttachments)
                    .WithOne(a => a.Events)
                    .HasForeignKey(a => a.EventsId);

            builder.HasMany(a => a.EventAgenda)
                    .WithOne(a => a.Events)
                    .HasForeignKey(a => a.EventsId);

            builder.HasMany(a => a.Views)
                    .WithOne(a => a.Events)
                    .HasForeignKey(a => a.EventsId);

            builder.HasMany(a => a.EventsComments)
                    .WithOne(a => a.Events)
                    .HasForeignKey(a => a.EventsId);



        }
    }
}
