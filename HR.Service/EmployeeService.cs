using AutoMapper;
using HR.Domain.Common.IUnitOfWork;
using HR.Domain.DTOs;
using HR.Domain.Entities;
using HR.Service.IServices;
using System.Linq.Expressions;

namespace HR.Service
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.Repository<Employee>().Add(employee);
        }

        public  async Task AddAsync(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            await _unitOfWork.Repository<Employee>().AddAsync(employee);
        }

        public void Delete(int id)
        {
            Employee? employee = _Get(x => x.Id == id);

            if (employee != null)
                _unitOfWork.Repository<Employee>().Delete(employee);
        }

        public EmployeeDto? Get(Expression<Func<Employee, bool>> filter)
        {
            Employee? employeeFromDb = _Get(filter);

            if (employeeFromDb != null)
                return _mapper.Map<EmployeeDto>(employeeFromDb);

            return null;
        }

        public async Task<EmployeeDto?> GetAsync(Expression<Func<Employee, bool>> filter)
        {
            Employee? employeeFromDb = await _GetAsync(filter);

            if (employeeFromDb != null)
                return _mapper.Map<EmployeeDto>(employeeFromDb);

            return null;
        }

        public IEnumerable<EmployeeDto> GetAll(Expression<Func<Employee, bool>>? filter = null)
        {
            IEnumerable<Employee> employeesFromDb = _unitOfWork.Repository<Employee>().GetAll(filter);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(Expression<Func<Employee, bool>>? filter = null)
        {
            IEnumerable<Employee> employeesFromDb = await _unitOfWork.Repository<Employee>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
        }

        public void Update(int id, EmployeeDto employeeDto)
        {
            Employee? employee = _Get(x=>x.Id == id);

            if (employee != null)
            {
                _mapper.Map(employeeDto, employee);
                _unitOfWork.Repository<Employee>().Update(employee);
            }
        }

        private Employee? _Get(Expression<Func<Employee, bool>> filter) => _unitOfWork.Repository<Employee>().Get(filter);
        private async Task<Employee?> _GetAsync(Expression<Func<Employee, bool>> filter) => await _unitOfWork.Repository<Employee>().GetAsync(filter);
    }
}
