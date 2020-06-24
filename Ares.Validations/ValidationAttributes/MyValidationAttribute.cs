using Ares.Validations.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.Validations.ValidationAttributes
{
    public class MyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext != null)
            {
                ICustomerService customerService = (ICustomerService)validationContext.GetService(typeof(ICustomerService));

            }

            return base.IsValid(value, validationContext);
        }
    }
}
