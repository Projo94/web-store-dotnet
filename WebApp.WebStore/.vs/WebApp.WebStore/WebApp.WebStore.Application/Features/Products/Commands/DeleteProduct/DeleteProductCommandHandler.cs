using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Exceptions;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Products.Commands.DeleteOrder
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.ProductId);

            if (productToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            await _productRepository.DeleteAsync(productToDelete);

            return Unit.Value;
        }
    }
}
