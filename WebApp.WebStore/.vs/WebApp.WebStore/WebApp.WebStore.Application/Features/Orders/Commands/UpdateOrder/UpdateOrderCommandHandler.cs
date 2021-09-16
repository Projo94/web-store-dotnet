using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UpdateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWorks)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWorks;
        }



        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _unitOfWork.OrderRepository.GetByIdAsync(request.Uid);

            var newOrderItems = request.OrderItems.Where(c => c.OrderItemID == 0).ToList();

            var updateOrderItems = request.OrderItems.Where(c => c.OrderItemID > 0).ToList();


            //  _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));




            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {

                    if (newOrderItems.Count > 0)
                    {
                        var @orderItems = _mapper.Map<List<OrderItem>>(newOrderItems);

                        @orderItems = orderItems.Select(c =>
                        {
                            c.Uid = request.Uid; // setting up orderid from order item to particular order
                            return c;

                        }).ToList();

                        await _unitOfWork.OrderItemRepository.AddRange(@orderItems); //saving the order items
                        await _unitOfWork.OrderItemRepository.SaveChangesAsync();


                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }



            //await _unitOfWork.OrderItemRepository.AddRange(newOrderItems);

            return Unit.Value;

        }
    }
}
