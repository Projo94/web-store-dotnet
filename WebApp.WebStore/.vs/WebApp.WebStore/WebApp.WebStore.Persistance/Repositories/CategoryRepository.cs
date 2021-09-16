using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        new WebStoreDbContext _dbContext;

        public CategoryRepository(WebStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetProductCategories(Guid productId)
        {
            return await _dbContext.Categories.FromSqlRaw("SELECT c.CategoryID, c.Caption FROM Categories c JOIN ProductsCategories pc on c.CategoryID = pc.CategoryID where pc.ProductID={0}", productId).ToListAsync();
        }

    }
}
