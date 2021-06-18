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
using WebApp.WebStore.Application.Models.Mail;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IEmailService emailService = null)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }



        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator(_orderRepository);
            var validationResult = await validator.ValidateAsync(request);


            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @order = _mapper.Map<Order>(request);
            @order = await _orderRepository.AddAsync(@order);

            var email = new Email()
            {
                To = "markoprojovic@gmail.com",
                Body = $"A new order was created: {request}",
                Subject = "A new order was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged

            }


            return @order.Uid;

        }






    }
}
