using AutoMapper;
using HR.Domain.DTOs;
using HR.Domain.Entities;

namespace HR.Service.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
