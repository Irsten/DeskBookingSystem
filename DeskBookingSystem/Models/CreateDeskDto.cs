using DeskBookingSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace DeskBookingSystem.Models
{
    public class CreateDeskDto
    {
        [Required]
        public int DeskNumber { get; set; }
        [Required]
        public State State { get; set; }
        [Required]
        public int LocationId { get; set; }
    }
}
