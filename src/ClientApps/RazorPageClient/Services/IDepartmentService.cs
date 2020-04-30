using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageClient.ViewModels.DepartmentsViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPageClient.Services
{
    public interface IDepartmentService : IScopedService
    {
        Task<List<CountryDetailsViewModel>> GetDepartmentListAsync();

        Task<SelectList> GetDepartmentSelectListAsync(int? selectedDepartment = null);

        Task CreateDepartmentAsync(CreateCountryViewModel createDepartmentViewModel);

        Task<CountryDetailsViewModel> GetDepartmentAsync(int departmentId);

        Task UpdateDepartmentAsync(UpdateCountryViewModel updateDepartmentViewModel);

        Task DeleteDepartmentAsync(int departmentId);
    }
}
