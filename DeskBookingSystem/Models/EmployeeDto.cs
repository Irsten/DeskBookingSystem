using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public enum Role
    {
        Employee,
        Administrator,
    }
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        /*public List<BookingDto> Bookings { get; set; }*/
    }
}
