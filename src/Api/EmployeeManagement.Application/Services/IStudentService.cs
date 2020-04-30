using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using EmployeeManagement.Application.Dtos.StudentDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public interface IStudentService : IScopedService
    {
        Task<List<StudentDetailsDto>> GetStudentListAsync();

        Task<StudentDetailsDto> GetStudentDetailsAsync(int studentId);

        Task CreateStudentAsync(CreateStudentDto createStudentDto);

        Task UpdateStudentAsync(UpdateStudentDto updateStudentDto);

        Task DeleteStudent(int studentId);
    }
}
