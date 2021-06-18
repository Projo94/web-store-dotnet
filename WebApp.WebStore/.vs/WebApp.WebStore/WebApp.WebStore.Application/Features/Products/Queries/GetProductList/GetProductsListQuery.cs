using MediatR;
using System.Collections.Generic;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListQuery : IRequest<List<ProductListVm>>
    {
    }
}
