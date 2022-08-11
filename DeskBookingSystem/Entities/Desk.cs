namespace DeskBookingSystem.Entities
{
    public enum State
    {
        Available,
        Unavailable,
    }
    public class Desk
    {
        public int Id { get; set; }
        public int DeskNumber { get; set; }
        public State State { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
