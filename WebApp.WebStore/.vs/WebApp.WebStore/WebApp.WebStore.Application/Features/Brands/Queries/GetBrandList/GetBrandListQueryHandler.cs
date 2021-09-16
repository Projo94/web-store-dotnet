using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Brands.Queries.GetBrandList
{
    public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, List<BrandListVm>>
    {

        private readonly IAsyncRepository<BrandType> _brandTypeRepository;
        private readonly IMapper _mapper;

        public GetBrandListQueryHandler(IAsyncRepository<BrandType> brandTypeRepository, IMapper mapper)
        {
            _brandTypeRepository = brandTypeRepository;
            _mapper = mapper;
        }


        public async Task<List<BrandListVm>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            var allBrandTypes = (await _brandTypeRepository.ListAllAsync()).OrderBy(x => x.Caption);

            return _mapper.Map<List<BrandListVm>>(allBrandTypes);

        }
    }
}
