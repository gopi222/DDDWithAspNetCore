using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.CountryViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [DisplayName("Country Name")]
        [MinLength(3, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(20, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string CountryName { get; set; }
    }
}
