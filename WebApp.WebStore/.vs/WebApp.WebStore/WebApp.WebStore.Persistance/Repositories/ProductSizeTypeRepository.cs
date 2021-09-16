using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class ProductSizeTypeRepository : BaseRepository<ProductSizeType>, IProductSizeTypeRepository
    {
        public ProductSizeTypeRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }

        public Task<ProductSizeType> GetProductSizeType(Guid productId, int sizeTypeID)
        {
            return Task.FromResult(_dbContext.ProductsSizeTypes.FromSqlRaw("Select * From ProductsSizeTypes Where ProductID = {0} and SizeTypeID= {1}", productId, sizeTypeID).FirstOrDefault());
        }

        public Task<List<ProductSizeType>> GetProductSizeTypes(Guid productId)
        {
            return Task.FromResult(_dbContext.ProductsSizeTypes.FromSqlRaw("Select * From ProductsSizeTypes Where ProductID = {0}", productId).ToList());
        }
    }
}
