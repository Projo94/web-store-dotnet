using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Features.Orders.Queries.GetOrdersExport
{
    public class OrderExportFileVm
    {
        public string OrderExportFileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

    }


}
