using System.Text;

namespace Events.Infrastructure.Context
{
    public class ContextSeed
    {
        private static DBContext _dbContext;
        private static IServiceProvider _serviceProvider;

        public static void Seed(DBContext appDbContext, IServiceProvider serviceProvider)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;
            Seedlk_EventsStatus();
            SeedSectors();
            //SeedEvents();
        }

        private static void SeedEvents()
        {
            if (!_dbContext.Events.Any())
            {
                string SeedingEvents = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "Events.json", Encoding.UTF8);
                var AllEvents = JsonConvert.DeserializeObject<List<EventsModel>>(SeedingEvents);

                if (AllEvents != null)
                {
                    foreach (var item in AllEvents)
                    {
                        item.CreatedOn = DateTime.Now;
                        item.UpdatedOn = DateTime.Now;
                        item.CreatedBy = Guid.NewGuid();
                        item.UpdatedBy = null;
                        _dbContext.Events.Add(item);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
        private static void SeedSectors()
        {
            if (!_dbContext.Sectors.Any())
            {
                string SeedingSectors = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "Sectors.json", Encoding.UTF8);
                var AllSectors = JsonConvert.DeserializeObject<List<Sector>>(SeedingSectors);

                if (AllSectors != null)
                {
                    foreach (var item in AllSectors)
                    {
                        item.CreatedOn = DateTime.Now;
                        item.UpdatedOn = DateTime.Now;
                        item.CreatedBy = Guid.NewGuid();
                        item.UpdatedBy = null;
                        _dbContext.Sectors.Add(item);
                        _dbContext.SaveChanges();
                    }
                }
            }
            else 
            {
                string SeedingSectors = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "Sectors.json", Encoding.UTF8);
                var AllSectors = JsonConvert.DeserializeObject<List<Sector>>(SeedingSectors);

              var events = _dbContext.Events.ToList();
                var sectors = _dbContext.Sectors.ToList();
                var sectorIds = AllSectors.Select(x => x.Id).ToList();
                var allEvents = events.Where(x=> !sectorIds.Any(n=>n == x.SectorId) && x.SectorId !=null).ToList();
                if (allEvents.Any())
                {
                    allEvents.ForEach(n =>
                    {
                        n.SectorId = null;
                    });
                    _dbContext.Events.UpdateRange(allEvents);
                    _dbContext.SaveChanges();
                }
                var allOldSectors = sectors.Where(x => !sectorIds.Any(n => n == x.Id)).ToList();
                if (allOldSectors.Any()) { 
                    _dbContext.Sectors.RemoveRange(allOldSectors);
                    _dbContext.SaveChanges();
                }
                var ids = sectors.Select(x => x.Id).ToList();
                var allNewSectors = AllSectors.Where(x => !ids.Any(n => n == x.Id)).ToList();
                if (allNewSectors.Any())
                {
                    _dbContext.Sectors.AddRange(allNewSectors);
                    _dbContext.SaveChanges();
                }
            }
        }
        private static void Seedlk_EventsStatus()
        {
            string Lk_NewsStatusJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "LK_EventsStatus.json", Encoding.UTF8);
            var lk_NewsStatuses = JsonConvert.DeserializeObject<List<LK_EventsStatus>>(Lk_NewsStatusJson);

            if (lk_NewsStatuses != null && lk_NewsStatuses.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.LK_EventsStatuses.Any())
                    {
                        foreach (var lk_NewsStatuse in lk_NewsStatuses)
                        {
                            lk_NewsStatuse.CreatedOn = DateTime.Now;
                        }

                        _dbContext.LK_EventsStatuses.AddRange(lk_NewsStatuses);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingNewsStatuses = _dbContext.LK_EventsStatuses.ToList();
                        var newlk_NewsStatuses = lk_NewsStatuses
                            .Where(ns => !existingNewsStatuses.Any(ep => ep.NameEn == ns.NameEn))
                            .ToList();

                        if (newlk_NewsStatuses.Any())
                        {
                            foreach (var SocialMedia in newlk_NewsStatuses)
                            {
                                SocialMedia.CreatedOn = DateTime.Now;
                            }

                            _dbContext.LK_EventsStatuses.AddRange(newlk_NewsStatuses);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }

        }
    }
}
