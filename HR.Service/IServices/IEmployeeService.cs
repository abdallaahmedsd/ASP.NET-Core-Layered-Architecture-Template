using HR.Domain.DTOs;
using HR.Domain.Entities;
using System.Linq.Expressions;

namespace HR.Service.IServices
{
    public interface IEmployeeService : IBaseService
    {
        EmployeeDto? Get(Expression<Func<Employee, bool>> filter);
        Task<EmployeeDto?> GetAsync(Expression<Func<Employee, bool>> filter);
        IEnumerable<EmployeeDto> GetAll(Expression<Func<Employee, bool>>? filter = null);
        Task<IEnumerable<EmployeeDto>> GetAllAsync(Expression<Func<Employee, bool>>? filter = null);
        void Add(EmployeeDto employeeDto);
        Task AddAsync(EmployeeDto employeeDto);
        void Update(int id, EmployeeDto employeeDto);
        void Delete(int id);
    }
}
