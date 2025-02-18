namespace HR.Model
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
