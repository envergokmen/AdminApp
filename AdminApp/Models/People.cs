using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class People
    {
        [Required( ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Lng.App))]
        [StringLength(50, ErrorMessageResourceName = "TooLong", ErrorMessageResourceType = typeof(Lng.App))]
        [Display(Name="Name", ResourceType = typeof(Lng.App))]
        public string Name { get; set; }
    }
}
