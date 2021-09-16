using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        new WebStoreDbContext _dbContext;

        public ProductRepository(WebStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
