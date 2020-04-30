using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Dtos.CountryDtos
{
    public class CountryDetailsDto
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
