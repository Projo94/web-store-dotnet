using System.Collections.Generic;
using WebApp.WebStore.Application.Features.Orders.Queries.GetOrdersExport;

namespace WebApp.WebStore.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportOrdersToCsv(List<OrderExportDto> eventExportDtos);
    }
}
