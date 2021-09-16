using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Pictures.Commands.CreatePicture
{
    public class CreatePictureCommandValidator : AbstractValidator<CreatePictureCommand>
    {

        private readonly IAsyncRepository<Product> _productRepository;




        public CreatePictureCommandValidator(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;



            RuleFor(e => e)
               .MustAsync(ProductExists)
               .WithMessage("Product doesn't exist!");

            RuleFor(p => p).Must(pictures => pictures.listOfPictures.Count >= 3)
                .WithMessage("Product must have at least 3 pictures");

        }

        private async Task<bool> ProductExists(CreatePictureCommand e, CancellationToken token)
        {
            return await _productRepository.Exists(e.ProductID);

        }



    }
}