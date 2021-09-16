using MediatR;
using System.Collections.Generic;

namespace WebApp.WebStore.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
