using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.OrderId);

            await _orderRepository.DeleteAsync(orderToDelete);

            return Unit.Value;
        }
    }
}
