using DeskBookingSystem.Entities;

namespace DeskBookingSystem.Models
{
    public enum State
    {
        Available,
        Unavailable,
    }
    public class DeskDto
    {
        public int Id { get; set; }
        public int DeskNumber { get; set; }
        public State State { get; set; }
    }
}
