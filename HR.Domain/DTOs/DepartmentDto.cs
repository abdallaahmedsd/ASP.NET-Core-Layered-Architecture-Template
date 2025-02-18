using System.ComponentModel.DataAnnotations;

namespace HR.Domain.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
