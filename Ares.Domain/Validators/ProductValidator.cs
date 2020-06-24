using Ares.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Validations
{
    // dotnet add package FluentValidation
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UnitPrice).InclusiveBetween(1, 100);
        }
    }
}
