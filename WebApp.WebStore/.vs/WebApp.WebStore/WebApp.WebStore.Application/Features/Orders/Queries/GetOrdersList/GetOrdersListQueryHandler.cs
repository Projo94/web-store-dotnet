using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderListVm>>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;


        public GetOrdersListQueryHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }


        public async Task<List<OrderListVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var allOrders = (await _orderRepository.ListAllAsync()).OrderBy(x => x.CreateDateUtc);
            return _mapper.Map<List<OrderListVm>>(allOrders);
        }
    }
}
