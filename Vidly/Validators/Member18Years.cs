using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Validators
{
    public class Member18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerFormViewModel) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth.HasValue)
            {
                var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;
                return age >= 18
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be 18 years to be a member.");
            }
            else
            {
                return new ValidationResult("Birthdate is required");
            }
        }
    }
}