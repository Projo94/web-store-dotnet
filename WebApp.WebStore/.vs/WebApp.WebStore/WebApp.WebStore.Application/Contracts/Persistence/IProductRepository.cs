using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {



    }
}
