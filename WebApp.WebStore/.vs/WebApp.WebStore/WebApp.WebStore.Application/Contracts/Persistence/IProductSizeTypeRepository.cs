using System;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IProductSizeTypeRepository : IAsyncRepository<ProductSizeType>
    {
        public Task<ProductSizeType> GetProductSizeType(Guid productId, int sizeTypeID);
    }
}
