using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IPictureRepository : IAsyncRepository<Picture>
    {
        Task<List<Picture>> GetPicturesForProduct(Guid productId);


    }
}
