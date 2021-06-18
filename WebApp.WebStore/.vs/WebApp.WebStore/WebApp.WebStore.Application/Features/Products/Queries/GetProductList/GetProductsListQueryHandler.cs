using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductListVm>>
    {

        private readonly IAsyncRepository<Product> _productRepository;

        private readonly IMapper _mapper;


        public GetProductsListQueryHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);

            return _mapper.Map<List<ProductListVm>>(allProducts);
        }
    }
}
