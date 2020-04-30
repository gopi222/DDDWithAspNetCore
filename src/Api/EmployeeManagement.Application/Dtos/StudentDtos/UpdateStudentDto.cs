using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Dtos.StudentDtos
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int CountryId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string SpokenLanguage { get; set; }
    }
}
