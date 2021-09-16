using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        new WebStoreDbContext _dbContext;

        public ProductCategoryRepository(WebStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductCategory> GetProductCategory(Guid productId, int sizeTypeID)
        {
            return await _dbContext.ProductsCategories.FromSqlRaw("SELECT CategoryID, ProductID FROM ProductsCategories where ProductID={0} and CategoryID={1}", productId, sizeTypeID).FirstOrDefaultAsync();

        }
    }
}
