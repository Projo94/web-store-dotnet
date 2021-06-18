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

namespace WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;


        public UpdateOrderCommandHandler(IMapper mapper, IAsyncRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }



        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Uid);
            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _orderRepository.UpdateAsync(orderToUpdate);

            return Unit.Value;

        }
    }
}
