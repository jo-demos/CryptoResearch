using System;
using System.ComponentModel.DataAnnotations;
using CryptoResearch.Models;

namespace CryptoResearch.Validations
{
    public class NotNewBrokersAcceptedAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Broker broker = (Broker)validationContext.ObjectInstance;

            if (broker.Foundation > DateTime.Now.AddYears(-5))
            {
                return new ValidationResult("Brokers under 5 years registration, are not accepted");
            }

            return ValidationResult.Success;
        }
    }
}