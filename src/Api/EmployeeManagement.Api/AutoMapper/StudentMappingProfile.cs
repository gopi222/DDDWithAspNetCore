using AutoMapper;
using EmployeeManagement.Api.ApiModels.StudentModels;
using EmployeeManagement.Application.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.AutoMapper
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<CreateStudentModel, CreateStudentDto>();
            CreateMap<UpdateStudentModel, UpdateStudentDto>();
            CreateMap<StudentDetailsDto, StudentDetailsModel>();
        }
    }
}
