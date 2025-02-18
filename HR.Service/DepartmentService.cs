using AutoMapper;
using HR.Domain.Common.IUnitOfWork;
using HR.Domain.DTOs;
using HR.Domain.Entities;
using HR.Service.IServices;
using System.Linq.Expressions;

namespace HR.Service
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.Repository<Department>().Add(department);
        }

        public async Task AddAsync(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            await _unitOfWork.Repository<Department>().AddAsync(department);
        }

        public void Delete(int id)
        {
            Department? department = _Get(x => x.Id == id);

            if (department != null)
                _unitOfWork.Repository<Department>().Delete(department);
        }

        public DepartmentDto? Get(Expression<Func<Department, bool>> filter)
        {
            Department? departmentFromDb = _Get(filter);

            if (departmentFromDb != null)
                return _mapper.Map<DepartmentDto>(departmentFromDb);

            return null;
        }

        public async Task<DepartmentDto?> GetAsync(Expression<Func<Department, bool>> filter)
        {
            Department? departmentFromDb = await _GetAsync(filter);

            if (departmentFromDb != null)
                return _mapper.Map<DepartmentDto>(departmentFromDb);

            return null;
        }

        public IEnumerable<DepartmentDto> GetAll(Expression<Func<Department, bool>>? filter = null)
        {
            IEnumerable<Department> departmentsFromDb = _unitOfWork.Repository<Department>().GetAll(filter);
            return _mapper.Map<IEnumerable<DepartmentDto>>(departmentsFromDb);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync(Expression<Func<Department, bool>>? filter = null)
        {
            IEnumerable<Department> departmentsFromDb = await _unitOfWork.Repository<Department>().GetAllAsync(filter);
            return _mapper.Map<IEnumerable<DepartmentDto>>(departmentsFromDb);
        }

        public void Update(int id, DepartmentDto departmentDto)
        {
            Department? department = _Get(x => x.Id == id);

            if (department != null)
            {
                _mapper.Map(departmentDto, department);
                _unitOfWork.Repository<Department>().Update(department);
            }
        }

        private Department? _Get(Expression<Func<Department, bool>> filter) => _unitOfWork.Repository<Department>().Get(filter);
        private async Task<Department?> _GetAsync(Expression<Func<Department, bool>> filter) => await _unitOfWork.Repository<Department>().GetAsync(filter);
    }
}
