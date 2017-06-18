using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models
{
    public class Min18YearsToRegister : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var recipient = (Recipient) validationContext.ObjectInstance;

            return (DateTime.Now.AddYears(-18) >= recipient.BirthDate)
                ? ValidationResult.Success 
                : new ValidationResult("Recipient should be at least 18 years old.");
        }
    }
}