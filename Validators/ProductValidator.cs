using FluentValidation;
using FluentValidationExample.Errors;
using FluentValidationExample.Models;
using System.Linq;

namespace FluentValidationExample.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Products)
                .NotNull()
                .WithMessage(ProductErrors.ProductErrorMessage)
                .Must(x => x.Any())
                .WithMessage(ProductErrors.ProductErrorMessage);

            RuleFor(x => x.Products.Select(p => p.Id))
               .Must(x => !x.Any(s => s <= 0))
               .WithMessage(ProductErrors.IdErrorMessage);

            RuleFor(x => x.Products.Select(p => p.Seller))
               .Must(n => !n.Any(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)))
               .WithMessage(ProductErrors.SellerErrorMessage);

            RuleFor(x => x.Products.Select(p => p.Name))
                .Must(x => !x.Any(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)))
                .WithMessage(ProductErrors.NameErrorMessage);

            RuleFor(x => x.Products.Select(p => p.CatRefId))
                .Must(x => !x.Any(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s)))
                .WithMessage(ProductErrors.CatRefIdErrorMessage);

            RuleFor(x => x.Products.Select(p => p.Quantity))
               .Must(x => !x.Any(s => s <= 0))
               .WithMessage(ProductErrors.QuantityErrorMessage);
        }
    }
}
