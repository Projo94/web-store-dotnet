using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence.Dapper;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;

namespace WebApp.WebStore.Persistance.DapperRepositories
{
    public class ProductRepositoryDapper : IProductRepositoryDapper
    {
        private IDbConnection db;

        public ProductRepositoryDapper(IConfiguration configuration)
        {

            this.db = new SqlConnection(configuration.GetConnectionString("WebStoreConnectionString"));
        }

        public async Task<List<BestBuyProductVm>> GetBestBuyProductsInLastMonth()
        {
            var sql = @"exec GetBestBuyProductsInLastMonthSP";

            var result = await db.QueryAsync<BestBuyProductVm>(sql);

            return result.ToList();
        }
    }
}
