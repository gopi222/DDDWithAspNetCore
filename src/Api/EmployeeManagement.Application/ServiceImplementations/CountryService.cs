using EmployeeManagement.Application.Dtos.CountryDtos;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository.Services;

namespace EmployeeManagement.Application.ServiceImplementations
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CountryDetailsDto>> GetCountryListAsync()
        {
            List<CountryDetailsDto> countryList = await _unitOfWork.Repository<Country>().Entities
                .Select(d => new CountryDetailsDto
                {
                    CountryId = d.CountryId,
                    CountryName = d.CountryName,
                    IsActive = d.IsActive,
                    CreatedAtUtc = d.CreatedAtUtc,
                    LastModifiedAtUtc = d.LastModifiedAtUtc
                }).ToListAsync();

            return countryList;
        }

        public async Task CreateCountryAsync(CreateCountryDto createCountryDto)
        {
            if (createCountryDto == null)
            {
                throw new ArgumentNullException(nameof(createCountryDto));
            }

            Country countryToBeCreated = new Country()
            {
                CountryName = createCountryDto.CountryName
            };

            await _unitOfWork.Repository<Country>().InsertEntityAsync(countryToBeCreated);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<SelectList> GetCountrySelectListAsync(int? selectedCountryId)
        {
            var country = await _unitOfWork.Repository<Country>().Entities.Select(d => new
            {
                d.CountryId,
                d.CountryName
            }).ToListAsync();
            return new SelectList(country, "CountryId", "CountryName", selectedCountryId);
        }

        public async Task<CountryDetailsDto> GetCountryAsync(int countryId)
        {
            CountryDetailsDto countryDetailsDto = await _unitOfWork.Repository<Country>().Entities.Where(d => d.CountryId == countryId)
                .Select(d => new CountryDetailsDto
                {
                    CountryId = d.CountryId,
                    CountryName = d.CountryName,
                    IsActive = d.IsActive,
                    CreatedAtUtc = d.CreatedAtUtc,
                    LastModifiedAtUtc = d.LastModifiedAtUtc
                }).FirstOrDefaultAsync();

            return countryDetailsDto;
        }

        public async Task UpdateCountryAsync(UpdateCountryDto updateCountryDto)
        {
            if (updateCountryDto == null)
            {
                throw new ArgumentNullException(nameof(updateCountryDto));
            }

            Country countryToBeUpdated = await _unitOfWork.Repository<Country>().GetEntityByIdAsync(updateCountryDto.CountryId);
            if (countryToBeUpdated != null)
            {
                countryToBeUpdated.CountryName = updateCountryDto.CountryName;
                countryToBeUpdated.IsActive = updateCountryDto.IsActive;
                _unitOfWork.Repository<Country>().UpdateEntity(countryToBeUpdated);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteCountry(int countryId)
        {
            Country countryToBeDeleted = await _unitOfWork.Repository<Country>().GetEntityByIdAsync(countryId);
            if (countryToBeDeleted != null)
            {
                _unitOfWork.Repository<Country>().DeleteEntity(countryToBeDeleted);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
