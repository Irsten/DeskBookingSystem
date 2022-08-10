using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DeskBookingSystem.Entities
{
    public class BookingDbContext : DbContext
    {
        private string _connectionString = "Server=RADEK;Database=DeskBookingDb;Trusted_Connection=True;";
        public DbSet<Location> Locations { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Desk>()
                .Property(d => d.DeskNumber)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingStartDate)
                .IsRequired();

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingEndDate)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
