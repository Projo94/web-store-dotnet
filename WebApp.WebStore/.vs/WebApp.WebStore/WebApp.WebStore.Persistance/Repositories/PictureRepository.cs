using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class PictureRepository : BaseRepository<Picture>, IPictureRepository
    {
        public PictureRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
