using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.StudentViewModels
{
    public class StudentDetailsViewModel
    {
        public int StudentId { get; set; }

        [DisplayName("Student Name")]
        public string StudentName { get; set; }

        public int CountryId { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Spoken Language")]
        public string SpokenLanguage { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
