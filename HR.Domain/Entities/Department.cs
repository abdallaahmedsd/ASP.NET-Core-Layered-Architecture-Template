using HR.Domain.Common;

namespace HR.Domain.Entities
{

    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}
