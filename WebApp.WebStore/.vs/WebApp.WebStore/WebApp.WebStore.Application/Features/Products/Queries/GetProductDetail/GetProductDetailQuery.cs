using MediatR;
using System;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public Guid id;

    }
}
