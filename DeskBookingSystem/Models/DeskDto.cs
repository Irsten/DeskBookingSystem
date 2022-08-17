 using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public class DeskDto
    {
        public int Id { get; set; }
        public int DeskNumber { get; set; }
        public State? State { get; set; }
        public DeskBookingDto? Booking { get; set; }
    }
}
