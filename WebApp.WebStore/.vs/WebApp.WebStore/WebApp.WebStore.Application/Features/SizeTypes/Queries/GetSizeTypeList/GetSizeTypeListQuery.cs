using MediatR;
using System.Collections.Generic;

namespace WebApp.WebStore.Application.Features.SizeTypes.Queries.GetSizeTypeList
{
    public class GetSizeTypeListQuery : IRequest<List<SizeTypeListVm>>
    {
    }
}
