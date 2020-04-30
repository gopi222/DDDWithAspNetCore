using AutoMapper;
using EmployeeManagement.Api.ApiModels.CountryModels;
using EmployeeManagement.Application.Dtos.CountryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.AutoMapper
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CreateCountryModel, CreateCountryDto>();
            CreateMap<CountryDetailsDto, CountryDetailsModel>();
            CreateMap<UpdateCountryModel, UpdateCountryDto>();
        }
    }
}
