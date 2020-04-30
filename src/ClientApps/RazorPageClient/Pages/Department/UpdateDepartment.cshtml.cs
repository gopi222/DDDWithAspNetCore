using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageClient.Services;
using RazorPageClient.ViewModels.DepartmentsViewModels;
using System;
using System.Threading.Tasks;

namespace RazorPageClient.Pages.Department
{
    public class UpdateDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        public UpdateDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [BindProperty]
        public UpdateCountryViewModel UpdateDepartmentViewModel { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(int departmentId)
        {
            try
            {
                CountryDetailsViewModel departmentDetailsViewModel = await _departmentService.GetDepartmentAsync(departmentId);

                if (departmentDetailsViewModel == null)
                {
                    return NotFound();
                }

                UpdateDepartmentViewModel = new UpdateCountryViewModel()
                {
                    DepartmentId = departmentDetailsViewModel.DepartmentId,
                    DepartmentName = departmentDetailsViewModel.DepartmentName,
                    Description = departmentDetailsViewModel.Description,
                };
            }
            catch (Exception)
            {
                ErrorMessage = "There is some problem with the service. Please try again. If the problem persists then contract with the system administrator.";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateDepartmentAsync(UpdateDepartmentViewModel);
                    return RedirectToPage("./DepartmentList");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "There is some problem with the service. Please try again. If the problem persists then contract with the system administrator.");
                }
            }

            return Page();
        }
    }
}