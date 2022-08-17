using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
