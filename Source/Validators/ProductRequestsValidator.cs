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
            .WithMessage("Name cannot be null, empty or greater than 100 characters.");

        RuleFor(t => t.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequestDto>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public UpdateProductRequestValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Name cannot be empty or greater than 100 characters");

        RuleFor(t => t.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero");
    }
}