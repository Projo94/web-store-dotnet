using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;


        public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailService = null)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }



        public async Task<Guid?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator(_unitOfWork.OrderRepository);
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @order = _mapper.Map<Order>(request);


            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {

                try
                {
                    var @orderItems = @order.OrderItems.ToList(); //getting order items before getting rid of from order

                    @order.OrderItems.Clear(); // clearing orderitems in order

                    @order = await _unitOfWork.OrderRepository.AddAsync(@order); //saving the order 

                    @orderItems = @orderItems.Select(c =>
                    {
                        c.Uid = @order.Uid; // setting up orderid from order item to particular order
                        return c;
                    }).ToList();


                    await _unitOfWork.OrderItemRepository.AddRange(@orderItems); //saving the order items

                    await _unitOfWork.OrderItemRepository.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return @order.Uid;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    return null;

                }

            }









        }






    }
}
