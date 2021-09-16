using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Features.Pictures.Queries.GetPictureDetail;

namespace WebApp.WebStore.Application.Features.Pictures.Queries.GetPicturesList
{
    public class GetPicturesForProductQuery : IRequest<List<PictureVm>>
    {
        public Guid ProductId { get; set; }
    }
}
