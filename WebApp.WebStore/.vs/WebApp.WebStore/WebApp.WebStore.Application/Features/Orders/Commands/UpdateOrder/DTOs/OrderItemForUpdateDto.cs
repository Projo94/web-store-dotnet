using System;


namespace WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder.DTOs
{
    public class OrderItemForUpdateDto
    {
        public int OrderItemID { get; set; }

        public Guid ProductID { get; set; }

        public double PricePerUnit { get; set; }

        public int Quantity { get; set; }

    }
}
