using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int CountryId { get; set; }

        public string SpokenLanguage { get; set; }

        public Country Country { get; set; }
    }
}
