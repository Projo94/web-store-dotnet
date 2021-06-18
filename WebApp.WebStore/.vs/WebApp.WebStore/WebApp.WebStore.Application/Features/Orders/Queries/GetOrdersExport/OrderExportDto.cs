using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Features.Orders.Queries.GetOrdersExport
{
    public class OrderExportDto
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
