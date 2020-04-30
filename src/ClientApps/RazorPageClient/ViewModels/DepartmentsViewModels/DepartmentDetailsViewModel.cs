﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.DepartmentsViewModels
{
    public class CountryDetailsViewModel
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
