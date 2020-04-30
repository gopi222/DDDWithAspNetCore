using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Dtos.CountryDtos
{
    public class UpdateCountryDto
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public bool IsActive { get; set; }
    }
}
