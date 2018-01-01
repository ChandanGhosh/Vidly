using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vidly.Models;
using Vidly.Persistance;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipTypeViewModel> MembershipTypes { get; set; } = new List<MembershipTypeViewModel>();
    }
}