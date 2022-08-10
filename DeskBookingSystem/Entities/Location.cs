namespace DeskBookingSystem.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Desk> Desks { get; set; }
    }
}
