using DeskBookingSystem.Entities;

namespace DeskBookingSystem
{
    public class DataSeeder
    {
        private readonly DeskBookingDbContext _dbContext;

        public DataSeeder(DeskBookingDbContext dbContext)
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

        /*private IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            return employees;
        }*/

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
                            State = State.Unavailable,
                            LocationId = 1,
                            Booking = new Booking()
                            {
                                BookingStartDate = new DateTime(2022, 08, 16),
                                BookingEndDate = new DateTime(2022, 08, 19),
                                Employee = new Employee()
                                {
                                    Name = "Michael",
                                    Role = Role.Administrator,
                                }
                            }
                        },
                        new Desk()
                        {
                            DeskNumber = 2,
                            State = State.Unavailable,
                            Booking = new Booking()
                            {
                                BookingStartDate = new DateTime(2022, 08, 17),
                                BookingEndDate = new DateTime(2022, 08, 19),
                                Employee = new Employee()
                                {
                                    Name = "Jim",
                                    Role = Role.Employee,
                                }
                            }
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
                            State = State.Unavailable,
                            Booking = new Booking()
                            {
                                BookingStartDate = new DateTime(2022, 08, 17),
                                BookingEndDate = new DateTime(2022, 08, 17),
                                Employee = new Employee()
                                {
                                    Name = "Pam",
                                    Role = Role.Administrator,
                                }
                            }
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
                            State = State.Unavailable,
                            Booking = new Booking()
                            {
                                BookingStartDate = new DateTime(2022, 08, 16),
                                BookingEndDate = new DateTime(2022, 08, 19),
                                Employee = new Employee()
                                {
                                    Name = "Angela",
                                    Role = Role.Employee,
                                }
                            }
                        },
                        new Desk()
                        {
                            DeskNumber = 3,
                            State = State.Unavailable,
                            Booking = new Booking()
                            {
                                BookingStartDate = new DateTime(2022, 08, 16),
                                BookingEndDate = new DateTime(2022, 08, 17),
                                Employee = new Employee()
                                {
                                    Name = "Kevin",
                                    Role = Role.Employee,
                                }
                            }
                        },
                    }
                }
            };

            return locations;
        }
    }
}
