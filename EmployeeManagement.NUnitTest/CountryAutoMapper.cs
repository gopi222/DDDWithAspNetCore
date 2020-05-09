using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EmployeeManagement.Api.AutoMapper;

namespace EmployeeManagement.NUnitTest
{
    class CountryAutoMapper
    {
        public static IMapper _mapper;

        public static IMapper Mapper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CountryMappingProfile());
                }
                );
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            return _mapper;
        }
    }
}
