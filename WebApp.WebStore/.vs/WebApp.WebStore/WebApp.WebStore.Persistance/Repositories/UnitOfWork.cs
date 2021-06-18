using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;

namespace WebApp.WebStore.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;


        private WebStoreDbContext _context;

        public IOrderRepository orderRepository;

        public IProductRepository productRepository;

        public IProductCategoryRepository productCategoryRepository;

        public IProductSizeTypeRepository productSizeTypeRepository;

        public IPictureRepository pictureRepository;



        public UnitOfWork(WebStoreDbContext context)
        {
            _context = context;
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                    this.orderRepository = new OrderRepository(_context);

                return orderRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                    this.productRepository = new ProductRepository(_context);

                return productRepository;
            }
        }

        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (this.productCategoryRepository == null)
                    this.productCategoryRepository = new ProductCategoryRepository(_context);

                return productCategoryRepository;
            }
        }

        public IProductSizeTypeRepository ProductSizeTypeRepository
        {

            get
            {
                if (this.productSizeTypeRepository == null)
                    this.productSizeTypeRepository = new ProductSizeTypeRepository(_context);

                return productSizeTypeRepository;
            }

        }

        public IPictureRepository PictureRepository
        {
            get
            {
                if (this.pictureRepository == null)
                    this.pictureRepository = new PictureRepository(_context);

                return pictureRepository;
            }

        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }


        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
