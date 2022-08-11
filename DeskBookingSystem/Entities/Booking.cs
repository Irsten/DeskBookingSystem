namespace DeskBookingSystem.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public int DeskId { get; set; }
        public virtual Desk Desk { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
