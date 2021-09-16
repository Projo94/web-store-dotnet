using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.SizeTypes.Queries.GetSizeTypeList
{
    public class GetSizeTypeListQueryHandler : IRequestHandler<GetSizeTypeListQuery, List<SizeTypeListVm>>
    {

        private readonly IAsyncRepository<SizeType> _sizeTypeRepository;
        private readonly IMapper _mapper;

        public GetSizeTypeListQueryHandler(IAsyncRepository<SizeType> sizeTypeRepository, IMapper mapper)
        {
            _sizeTypeRepository = sizeTypeRepository;
            _mapper = mapper;
        }


        public async Task<List<SizeTypeListVm>> Handle(GetSizeTypeListQuery request, CancellationToken cancellationToken)
        {
            var allSizeTypes = (await _sizeTypeRepository.ListAllAsync()).OrderBy(x => x.Caption);

            return _mapper.Map<List<SizeTypeListVm>>(allSizeTypes);

        }
    }
}
