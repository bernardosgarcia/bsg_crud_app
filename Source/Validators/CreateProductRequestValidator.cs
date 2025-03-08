using bsg_crud_app.Dtos;
using FluentValidation;

namespace bsg_crud_app.Validators;

/// <summary>
/// Class to validate product create request
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequestDto>
{

    /// <summary>
    /// Constructor
    /// </summary>
    public CreateProductRequestValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100)
            .WithMessage("Name cannot be null or empty");

        RuleFor(t => t.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}