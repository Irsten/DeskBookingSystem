using DeskBookingSystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace DeskBookingSystem.Models
{
    public class UpdateDeskDto
    {
        [Required]
        public State State { get; set; }
    }
}
