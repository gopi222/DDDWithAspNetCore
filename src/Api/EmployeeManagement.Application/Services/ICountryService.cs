using AspNetCore.ServiceRegistration.Dynamic.Interfaces;
using EmployeeManagement.Application.Dtos.CountryDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public interface ICountryService : IScopedService
    {
        Task<List<CountryDetailsDto>> GetCountryListAsync();

        Task CreateCountryAsync(CreateCountryDto createCountryDto);

        Task<SelectList> GetCountrySelectListAsync(int? selectedCountryId);

        Task<CountryDetailsDto> GetCountryAsync(int countryId);

        Task UpdateCountryAsync(UpdateCountryDto updateCountryDto);

        Task DeleteCountry(int countryId);
    }
}
