using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Features.Orders
{
    public class OrderDetailVm
    {
        public int OrderID { get; set; }
        public Guid Uid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public List<OrderItemDto> OrderItemDtoList { get; set; }
    }
}
