﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.EmployeeViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int EmployeeId { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }

        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
