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
        [StringLength(20, ErrorMessageResourceName = "TooLong", ErrorMessageResourceType = typeof(Lng.App))]
        [Display(Name="Name", ResourceType = typeof(Lng.App))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Lng.App))]
        [StringLength(20, ErrorMessageResourceName = "TooLong", ErrorMessageResourceType = typeof(Lng.App))]
        [Display(Name = "LastName", ResourceType = typeof(Lng.App))]
        public string LastName { get; set; }
    }
}
