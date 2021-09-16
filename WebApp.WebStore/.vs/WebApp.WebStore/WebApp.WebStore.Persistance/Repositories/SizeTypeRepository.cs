using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class SizeTypeRepository : BaseRepository<SizeType>, ISizeTypeRepository
    {
        new WebStoreDbContext _dbContext;
        public SizeTypeRepository(WebStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SizeType>> GetProductSizeTypes(Guid productId)
        {
            return await _dbContext.SizeTypes.FromSqlRaw("SELECT st.SizeTypeEID, st.Caption FROM SizeTypes st JOIN ProductsSizeTypes pst on st.SizeTypeEID = pst.SizeTypeID where pst.ProductID={0}", productId).ToListAsync();

        }


    }
}
