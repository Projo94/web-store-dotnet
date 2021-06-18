using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class ProductSizeTypeRepository : BaseRepository<ProductSizeType>, IProductSizeTypeRepository
    {
        public ProductSizeTypeRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }

        public List<ProductSizeType> GetProductSizeTypes(Guid productId)
        {
            return _dbContext.ProductsSizeTypes.FromSqlRaw("Select * From ProductsSizeTypes Where ProductID = {0}", productId).ToList();
        }
    }
}
