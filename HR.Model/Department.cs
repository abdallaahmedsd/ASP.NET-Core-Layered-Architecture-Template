namespace HR.Model
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } =  null!;
        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}
