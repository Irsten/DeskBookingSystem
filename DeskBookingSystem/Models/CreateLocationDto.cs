using System.ComponentModel.DataAnnotations;

namespace DeskBookingSystem.Models
{
    public class CreateLocationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
