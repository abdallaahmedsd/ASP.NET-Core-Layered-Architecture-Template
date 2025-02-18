using HR.Domain.DTOs;
using HR.Domain.Entities;
using System.Linq.Expressions;

namespace HR.Service.IServices
{
    public interface IDepartmentService : IBaseService
    {
        DepartmentDto? Get(Expression<Func<Department, bool>> filter);
        Task<DepartmentDto?> GetAsync(Expression<Func<Department, bool>> filter);
        IEnumerable<DepartmentDto> GetAll(Expression<Func<Department, bool>>? filter = null);
        Task<IEnumerable<DepartmentDto>> GetAllAsync(Expression<Func<Department, bool>>? filter = null);
        void Add(DepartmentDto departmentDto);
        Task AddAsync(DepartmentDto departmentDto);
        void Update(int id, DepartmentDto departmentDto);
        void Delete(int id);
    }
}
