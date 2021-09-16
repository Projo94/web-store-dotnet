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

        public IOrderItemRepository orderItemRepository;

        public IProductRepository productRepository;

        public ICategoryRepository categoryRepository;


        public IProductCategoryRepository productCategoryRepository;

        public IProductSizeTypeRepository productSizeTypeRepository;

        public ISizeTypeRepository sizeTypeRepository;


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

        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                    this.orderItemRepository = new OrderItemRepository(_context);

                return orderItemRepository;
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

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                    this.categoryRepository = new CategoryRepository(_context);

                return categoryRepository;
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


        public ISizeTypeRepository SizeTypeRepository
        {

            get
            {
                if (this.sizeTypeRepository == null)
                    this.sizeTypeRepository = new SizeTypeRepository(_context);

                return sizeTypeRepository;
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
