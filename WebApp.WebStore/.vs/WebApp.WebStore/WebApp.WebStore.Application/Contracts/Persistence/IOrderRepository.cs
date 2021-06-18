using System;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<bool> IsOrderPriceAndDateUnique(double price, DateTime orderDate);
    }
}
