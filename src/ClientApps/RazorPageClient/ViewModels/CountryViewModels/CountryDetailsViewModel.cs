using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageClient.ViewModels.CountryViewModels
{
    public class CountryDetailsViewModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        
        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime? LastModifiedAtUtc { get; set; }
    }
}
