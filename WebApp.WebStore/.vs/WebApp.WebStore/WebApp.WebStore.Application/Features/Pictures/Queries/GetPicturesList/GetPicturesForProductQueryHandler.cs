using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Features.Pictures.Queries.GetPictureDetail;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Pictures.Queries.GetPicturesList
{
    public class GetPicturesForProductQueryHandler : IRequestHandler<GetPicturesForProductQuery, List<PictureVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPictureRepository _pictureRepository;


        public GetPicturesForProductQueryHandler(IMapper mapper, IPictureRepository pictureRepository)
        {
            _mapper = mapper;
            _pictureRepository = pictureRepository;

        }

        public async Task<List<PictureVm>> Handle(GetPicturesForProductQuery request, CancellationToken cancellationToken)
        {
            var pictureEntities = await _pictureRepository.GetPicturesForProduct(request.ProductId);

            var picturesVm = _mapper.Map<IEnumerable<Picture>, IEnumerable<PictureVm>>(pictureEntities);


            return picturesVm.ToList();
        }

    }
}
