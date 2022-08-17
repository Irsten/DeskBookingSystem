using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public class BookingDeskDto
    {
        public int Id { get; set; }
        public int DeskNumber { get; set; }
        public State? State { get; set; }
    }
}
