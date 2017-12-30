using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Vidly.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }


        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        
    }
}