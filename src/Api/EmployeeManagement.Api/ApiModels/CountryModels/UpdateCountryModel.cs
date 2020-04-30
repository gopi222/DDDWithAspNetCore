using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.AutoMapper
{
    public class UpdateCountryModel
    {
        [Required]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string CountryName { get; set; }
    }
}
