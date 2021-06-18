using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<OrderItem> _orderItemRepository;

        public GetOrderDetailQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository, IAsyncRepository<OrderItem> orderItemRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;

        }



        public async Task<OrderDetailVm> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var @order = await _orderRepository.GetByIdAsync(request.Id);
            var orderDetailDto = _mapper.Map<OrderDetailVm>(@order);

            //var orderItemsList = await _orderItemRepository.GetByIdAsync(@order.Uid);
            //orderDetailDto.OrderItemDtoList = _mapper.Map <>

            return orderDetailDto;

        }
    }
}
