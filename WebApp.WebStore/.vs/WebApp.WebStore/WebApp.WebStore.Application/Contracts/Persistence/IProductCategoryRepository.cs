using System;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IProductCategoryRepository : IAsyncRepository<ProductCategory>
    {
        public Task<ProductCategory> GetProductCategory(Guid productId, int sizeTypeID);

    }
}
