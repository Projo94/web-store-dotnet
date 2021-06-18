using MediatR;
using System;

namespace WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }

    }
}
