using System;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder.DTOs
{
    public class OrderItemForCreationDto
    {
        public Guid ProductID { get; set; }

        public double PricePerUnit { get; set; }

        public int Quantity { get; set; }

    }
}
