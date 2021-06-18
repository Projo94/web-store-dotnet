using FluentValidation;
using WebApp.WebStore.Application.Contracts.Persistence;

namespace WebApp.WebStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.listOfCategories)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(p => p.Count >= 3)
                .WithMessage("Product should have at least 3 categories.");

            RuleFor(p => p.listOfPictures)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(p => p.Count >= 3)
            .WithMessage("Product should have at least 3 pictures.");


            RuleFor(p => p.listOfSizeTypes)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(p => p.Count >= 3)
            .WithMessage("Product should have at least 3 size types.");


        }
    }
}
