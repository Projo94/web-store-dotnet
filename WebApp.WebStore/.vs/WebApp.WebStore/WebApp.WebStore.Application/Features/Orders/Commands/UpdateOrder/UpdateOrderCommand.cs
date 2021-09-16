using MediatR;
using System;
using System.Collections.Generic;
using WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder.DTOs;

namespace WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Uid { get; set; }

        public List<OrderItemForUpdateDto> OrderItems { get; set; }

    }
}
