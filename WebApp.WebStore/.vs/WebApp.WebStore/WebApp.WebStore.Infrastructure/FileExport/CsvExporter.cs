using CsvHelper;
using System.Collections.Generic;
using System.IO;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Features.Orders.Queries.GetOrdersExport;

namespace WebApp.WebStore.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {


        public byte[] ExportOrdersToCsv(List<OrderExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                //using var csvWriter = new CsvWriter(streamWriter);
                //csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
