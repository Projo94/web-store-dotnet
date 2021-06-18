using System;
using System.Collections.Generic;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IProductSizeTypeRepository : IAsyncRepository<ProductSizeType>
    {

        public List<ProductSizeType> GetProductSizeTypes(Guid productId);
    }
}
