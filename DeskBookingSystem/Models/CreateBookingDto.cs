using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public class CreateBookingDto
    {
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public int DeskId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
