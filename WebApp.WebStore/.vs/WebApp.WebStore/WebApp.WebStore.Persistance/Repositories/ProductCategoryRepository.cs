using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ProductCategory> GetProductCategories(Guid productId)
        {
            return _dbContext.ProductsCategories.FromSqlRaw("Select * From ProductsCategories Where ProductID = {0}", productId).ToList();
        }


    }
}
