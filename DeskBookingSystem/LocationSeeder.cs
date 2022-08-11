using DeskBookingSystem.Entities;

namespace DeskBookingSystem
{
    public class LocationSeeder
    {
        private readonly DeskBookingDbContext _dbContext;

        public LocationSeeder(DeskBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Locations.Any())
                {
                    var locations = GetLocations();
                    _dbContext.Locations.AddRange(locations);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Location> GetLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                {
                    Name = "Room1",
                    Desks = new List<Desk>()
                    {
                        new Desk()
                        {
                            DeskNumber = 1,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 2,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 3,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 4,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 5,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 6,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 7,
                            State = State.Available,
                        },
                    }
                },
                new Location()
                {
                    Name = "Room2",
                    Desks = new List<Desk>()
                    {
                        new Desk()
                        {
                            DeskNumber = 1,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 2,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 3,
                            State = State.Available,
                        },
                        new Desk()
                        {
                            DeskNumber = 4,
                            State = State.Available,
                        },
                    }
                }
            };
            return locations;
        }
    }
}
