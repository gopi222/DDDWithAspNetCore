using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Dtos.StudentDtos
{
    public class StudentDetailsDto
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string SpokenLanguage { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
