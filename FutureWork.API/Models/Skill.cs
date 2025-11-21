using System.ComponentModel.DataAnnotations;

namespace FutureWork.API.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsFutureCritical { get; set; } = true;
    }
}
