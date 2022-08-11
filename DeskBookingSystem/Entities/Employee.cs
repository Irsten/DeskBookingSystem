namespace DeskBookingSystem.Entities
{
    public enum Role
    {
        Employee,
        Administrator,
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
