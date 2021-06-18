using System;

namespace WebApp.WebStore.Application.Features.Orders
{
    public class OrderListVm
    {
        public int OrderID { get; set; }
        public Guid Uid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateDateUtc { get; set; }
    }
}
