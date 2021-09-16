using System;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth
{
    public class BestBuyProductVm
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

    }
}
