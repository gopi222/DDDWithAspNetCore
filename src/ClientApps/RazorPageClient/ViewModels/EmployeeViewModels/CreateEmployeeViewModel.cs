﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.EmployeeViewModels
{
    public class CreateStudentViewModel
    {
        [Required]
        [DisplayName("Employee Name")]
        [MinLength(4, ErrorMessage = "{0} should be at least {1} characters long.")]
        [MaxLength(50)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please select your deparment.")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

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
    }
}
