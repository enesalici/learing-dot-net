using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("İsim alanı boş olamaz.");
            RuleFor(i => i.Stock).GreaterThanOrEqualTo(1);
            RuleFor(i => i.Price).GreaterThanOrEqualTo(1);
            RuleFor(i => i.CategoryId).GreaterThanOrEqualTo(1);

            // Kendi kuralımız.
            RuleFor(i => i.Name).Must(StartsWithA).WithMessage("İsim alanı a harfi ile başlamalıdır.");
        }

        public bool StartsWithA(string name)
        {
            return name.StartsWith("A");
        }
    }
}
