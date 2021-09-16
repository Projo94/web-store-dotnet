using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;

namespace WebApp.WebStore.Application.Contracts.Persistence.Dapper
{
    public interface IProductRepositoryDapper
    {

        Task<List<BestBuyProductVm>> GetBestBuyProductsInLastMonth();

    }
}
