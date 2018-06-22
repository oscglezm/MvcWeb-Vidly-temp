using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
 

namespace MovieWebApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if(customer.MemberShipTypeId == (byte)MemberShipType.MemberShipTypeEnum.Unknow 
               || customer.MemberShipTypeId ==  (byte)MemberShipType.MemberShipTypeEnum.PassAsYouGo)
                return ValidationResult.Success;

            var age = DateTime.Today.Year - customer.BirthDate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old");
        }
        
    }
}