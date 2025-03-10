using bsg_crud_app.Dtos;
using bsg_crud_app.Repositories.Interfaces;
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
    public CreateProductRequestValidator(IProductRepository productRepository)
    {
        RuleFor(t => t.Name)
            .NotEmpty().NotNull().WithMessage("Product name cannot be empty or null")
            .MaximumLength(100).WithMessage("Product name cannot be greater than 100 characters")
            // ReSharper disable once UnusedParameter.Local
            .MustAsync(async (name, cancellation) =>
            {
                var response = await productRepository.GetByNameAsync(name);
                return response == null;
            }).WithMessage("A product with that name already exists");

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
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(100).WithMessage("Product name cannot be greater than 100 characters");

        RuleFor(t => t.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero");
    }
}