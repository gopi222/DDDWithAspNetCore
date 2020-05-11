using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.StudentViewModels
{
    public class CreateStudentViewModel
    {
        [Required]
        [DisplayName("Student Name")]
        [MinLength(4, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please select your country.")]
        [DisplayName("Country")]
        public int CountryId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Email")]
        [MinLength(8, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [MinLength(10, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(15, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Spoken Language")]
        [MinLength(100, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(5, ErrorMessage = "{0} should not be more than {1} characters.")]
        public string SpokenLanguage { get; set; }
    }
}
