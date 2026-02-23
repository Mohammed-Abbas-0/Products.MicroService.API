using DataLogicLayer.DTO;
using FluentValidation;

namespace DataLogicLayer.Validators;
public class ProductAddRequestValidator:AbstractValidator<ProductAddRequest>
{
    public ProductAddRequestValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
        RuleFor(x => x.CategoryOptions).IsInEnum().WithMessage("Invalid category option.");
    }
}
