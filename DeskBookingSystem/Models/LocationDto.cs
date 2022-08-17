namespace DeskBookingSystem.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookingDeskDto>? Desks { get; set; }
    }
}
