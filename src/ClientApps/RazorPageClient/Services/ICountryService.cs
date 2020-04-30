using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageClient.ViewModels.CountryViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorPageClient.Services
{
    public interface ICountryService : IScopedService
    {
        Task<List<CountryDetailsViewModel>> GetCountryListAsync();

        Task<SelectList> GetCountrySelectListAsync(int? selectedCountry = null);

        Task CreateCountryAsync(CreateCountryViewModel createCountryViewModel);

        Task<CountryDetailsViewModel> GetCountryAsync(int countryId);

        Task UpdateCountryAsync(UpdateCountryViewModel updateCountryViewModel);

        Task DeleteCountryAsync(int countryId);
    }
}
