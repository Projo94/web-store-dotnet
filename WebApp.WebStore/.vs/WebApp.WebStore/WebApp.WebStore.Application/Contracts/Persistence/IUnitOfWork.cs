using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }

        IOrderItemRepository OrderItemRepository { get; }

        IProductRepository ProductRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IProductCategoryRepository ProductCategoryRepository { get; }

        IProductSizeTypeRepository ProductSizeTypeRepository { get; }

        ISizeTypeRepository SizeTypeRepository { get; }

        IPictureRepository PictureRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();


    }
}
