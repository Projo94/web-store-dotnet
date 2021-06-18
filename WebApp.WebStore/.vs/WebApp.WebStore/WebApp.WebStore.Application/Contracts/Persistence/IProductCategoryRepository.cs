using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IProductCategoryRepository : IAsyncRepository<ProductCategory>
    {
        public List<ProductCategory> GetProductCategories(Guid productId);

    }
}
