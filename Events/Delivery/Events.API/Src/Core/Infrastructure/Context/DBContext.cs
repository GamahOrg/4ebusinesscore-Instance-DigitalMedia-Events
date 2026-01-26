namespace Events.Infrastructure.Context
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LK_EventsStatus>()
               .Property(e => e.Id)
               .UseIdentityColumn(seed: 0, increment: 1);
        }
        public DbSet<Events.Domain.Models.Events> Events { get; set; }
        public DbSet<EventsAttachments> EventsAttachments { get; set; }
        public DbSet<EventsComment> EventsComments { get; set; }
        public DbSet<EventsRate> RateEvents { get; set; }
        public DbSet<EventsView> Views { get; set; }
        public DbSet<EventAgenda> EventsAgenda { get; set; }
        public DbSet<TimePeriod> TimePeriod { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<LK_EventsStatus> LK_EventsStatuses { get; set; }

        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}