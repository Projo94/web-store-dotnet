using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IOrderItemRepository : IAsyncRepository<OrderItem>
    {
    }
}
