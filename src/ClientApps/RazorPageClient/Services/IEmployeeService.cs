using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using RazorPageClient.ViewModels.EmployeeViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPageClient.Services
{
    public interface IEmployeeService : IScopedService
    {
        Task<List<EmployeeDetailsViewModel>> GetEmployeeListAsync();

        Task<EmployeeDetailsViewModel> GetEmployeeDetailsAsync(int employeeId);

        Task CreateEmployeeAsync(CreateStudentViewModel createEmployeeViewModel);

        Task UpdateEmplyeeAsync(UpdateStudentViewModel updateEmployeeViewModel);

        Task DeleteEmployee(int employeeId);
    }
}
