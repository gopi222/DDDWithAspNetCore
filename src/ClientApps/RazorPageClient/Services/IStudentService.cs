using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using RazorPageClient.ViewModels.StudentViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPageClient.Services
{
    public interface IStudentService : IScopedService
    {
        Task<List<StudentDetailsViewModel>> GetStudentListAsync();

        Task<StudentDetailsViewModel> GetStudentDetailsAsync(int studentId);

        Task CreateStudentAsync(CreateStudentViewModel createStudentViewModel);

        Task UpdateStudentAsync(UpdateStudentViewModel updateStudentViewModel);

        Task DeleteStudent(int studentId);
    }
}
