using HR.Domain.Entities;

namespace HR.Domain.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; } = null!;
    }
}
