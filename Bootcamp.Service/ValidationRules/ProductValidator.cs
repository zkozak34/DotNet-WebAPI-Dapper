using Bootcamp.Entities.Dtos;
using FluentValidation;

namespace Bootcamp.Service.ValidationRules
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Stock)
                .NotNull()
                .GreaterThanOrEqualTo(0);

        }
    }
}
