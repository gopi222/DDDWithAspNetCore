using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ApiModels.StudentModels
{
    public class UpdateStudentModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string StudentName { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string SpokenLanguage { get; set; }
    }
}
