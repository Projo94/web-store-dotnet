using MediatR;
using System.Collections.Generic;

namespace WebApp.WebStore.Application.Features.Brands.Queries.GetBrandList
{
    public class GetBrandListQuery : IRequest<List<BrandListVm>>
    {

    }
}
