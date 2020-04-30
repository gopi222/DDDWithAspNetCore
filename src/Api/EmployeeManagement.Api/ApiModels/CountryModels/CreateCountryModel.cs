using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ApiModels.CountryModels
{
    public class CreateCountryModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string CountryName { get; set; }
    }
}
