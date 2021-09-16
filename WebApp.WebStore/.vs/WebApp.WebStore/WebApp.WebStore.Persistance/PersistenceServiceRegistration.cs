
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Contracts.Persistence.Dapper;
using WebApp.WebStore.Persistance.DapperRepositories;
using WebApp.WebStore.Persistance.Repositories;

namespace WebApp.WebStore.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WebStoreConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepositoryDapper, ProductRepositoryDapper>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISizeTypeRepository, SizeTypeRepository>();
            services.AddScoped<IProductSizeTypeRepository, ProductSizeTypeRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
