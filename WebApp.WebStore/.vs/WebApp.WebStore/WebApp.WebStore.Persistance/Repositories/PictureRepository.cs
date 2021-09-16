using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class PictureRepository : BaseRepository<Picture>, IPictureRepository
    {
        public PictureRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<BestBuyProductVm>> GetBestBuyProductsInLastMonth()
        {
            var list = await _dbContext.Products.FromSqlRaw("Execute dbo.GetBestBuyProductsInLastMonthSP").ToListAsync();

            return null;
        }

        public async Task<List<Picture>> GetPicturesForProduct(Guid productID)
        {
            return await _dbContext.Pictures.FromSqlRaw("SELECT * FROM Pictures where ProductID={0}", productID).ToListAsync();
        }


    }
}
