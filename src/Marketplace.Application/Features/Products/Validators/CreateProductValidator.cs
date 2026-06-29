using FluentValidation;
using Marketplace.Application.Features.Products.Commands.CreateProduct;

namespace Marketplace.Application.Features.Products.Validators;

public class CreateProductValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Sku)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}