using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence.Dapper;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth
{
    public class GetBestBuyProductsInLastMonthHandler : IRequestHandler<GetBestBuyProductsInLastMonthQuery, List<BestBuyProductVm>>
    {
        private readonly IProductRepositoryDapper _productRepositoryDapper;

        public GetBestBuyProductsInLastMonthHandler(IProductRepositoryDapper productRepositoryDapper)
        {
            _productRepositoryDapper = productRepositoryDapper;
        }

        public async Task<List<BestBuyProductVm>> Handle(GetBestBuyProductsInLastMonthQuery request, CancellationToken cancellationToken)
        {
            return await _productRepositoryDapper.GetBestBuyProductsInLastMonth();
        }
    }
}
