using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }

    }
}
