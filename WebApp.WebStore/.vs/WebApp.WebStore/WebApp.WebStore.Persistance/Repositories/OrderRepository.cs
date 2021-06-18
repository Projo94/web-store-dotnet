using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(WebStoreDbContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsOrderPriceAndDateUnique(double price, DateTime orderDate)
        {
            var matches = _dbContext.Orders.Any(e => e.TotalPrice.Equals(price) && e.CreateDateUtc.Date.Equals(orderDate.Date));
            return Task.FromResult(matches);
        }
    }
}
