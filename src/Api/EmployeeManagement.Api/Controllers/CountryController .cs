using AutoMapper;
using EmployeeManagement.Api.ApiModels.CountryModels;
using EmployeeManagement.Api.AutoMapper;
using EmployeeManagement.Application.Dtos.CountryDtos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CountryDetailsModel>> GetCountryList()
        {
            List<CountryDetailsDto> countryDetailsDtos = await _countryService.GetCountryListAsync();
            List<CountryDetailsModel> countryList = _mapper.Map<List<CountryDetailsModel>>(countryDetailsDtos);
            return countryList;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryModel createCountryModel)
        {
            CreateCountryDto createCountryDto = _mapper.Map<CreateCountryDto>(createCountryModel);
            await _countryService.CreateCountryAsync(createCountryDto);
            return Ok();
        }

        [HttpGet]
        public async Task<SelectList> GetCountrySelectList(int? selectedCountry)
        {
            SelectList selectList = await _countryService.GetCountrySelectListAsync(selectedCountry);
            return selectList;
        }

        [HttpGet("{countryId}")]
        public async Task<CountryDetailsModel> GetCountry(int CountryId)
        {
            CountryDetailsDto countryDetailsDto = await _countryService.GetCountryAsync(CountryId);
            CountryDetailsModel countryDetailsModel = _mapper.Map<CountryDetailsModel>(countryDetailsDto);
            return countryDetailsModel;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryModel updateCountryModel)
        {
            UpdateCountryDto updateCountryDto = _mapper.Map<UpdateCountryDto>(updateCountryModel);
            await _countryService.UpdateCountryAsync(updateCountryDto);
            return Ok();
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountry(int CountryId)
        {
            await _countryService.DeleteCountry(CountryId);
            return Ok();
        }
    }
}