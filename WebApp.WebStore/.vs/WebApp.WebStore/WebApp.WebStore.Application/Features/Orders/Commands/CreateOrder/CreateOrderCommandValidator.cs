using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {

        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            RuleFor(p => p.TotalPrice).GreaterThan(0);
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            //}

            RuleFor(e => e)
                .MustAsync(OrderPriceAndDateUnique)
                .WithMessage("An order with the same price and date already exists.");

        }

        private async Task<bool> OrderPriceAndDateUnique(CreateOrderCommand e, CancellationToken token)
        {
            return !(await _orderRepository.IsOrderPriceAndDateUnique(e.TotalPrice, e.CreateDateUtc));

        }



    }
}