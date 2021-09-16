using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        public Task<List<Category>> GetProductCategories(Guid productId);

    }
}
