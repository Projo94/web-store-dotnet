using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Queries.GetOrdersExport
{
    public class GetOrdersExportQueryHandler : IRequestHandler<GetOrdersExportQuery, OrderExportFileVm>
    {

        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetOrdersExportQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _csvExporter = csvExporter;
        }

        public async Task<OrderExportFileVm> Handle(GetOrdersExportQuery request, CancellationToken cancellationToken)
        {
            var allOrders = _mapper.Map<List<OrderExportDto>>((await _orderRepository.ListAllAsync()).OrderBy(x => x.CreateDateUtc));

            var fileData = _csvExporter.ExportOrdersToCsv(allOrders);

            var orderExportFileDto = new OrderExportFileVm() { ContentType = "text/csv", Data = fileData, OrderExportFileName = $"{Guid.NewGuid()}.csv" };

            return orderExportFileDto;
        }
    }
}
