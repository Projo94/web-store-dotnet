using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface ISizeTypeRepository : IAsyncRepository<SizeType>
    {
        public Task<List<SizeType>> GetProductSizeTypes(Guid productId);
    }
}
