using FluentValidation;

namespace WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.listOfCategories)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .Must(p => p.Count >= 3)
                        .WithMessage("Product should have at least 3 categories.");



            RuleFor(p => p.listOfSizeTypes)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(p => p.Count >= 3)
                .WithMessage("Product should have at least 3 size types.");
        }


    }
}
