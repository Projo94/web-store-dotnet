using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder.DTOs;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid?>// returning value, when it is created, return a guid of newly created order
    {


        public CreateOrderCommand()
        {
            Uid = Guid.NewGuid();
            CreateDateUtc = DateTime.Now;
        }

        [JsonIgnore]
        public Guid Uid { get; set; }

        [JsonIgnore]
        public double TotalPrice
        {
            get
            {

                var totalPrice = (from item in OrderItems select item.Quantity * item.PricePerUnit).Sum();

                return totalPrice;
            }
        }

        [JsonIgnore]
        public DateTime CreateDateUtc { get; set; }

        public ICollection<OrderItemForCreationDto> OrderItems { get; set; }


        public override string ToString()
        {
            return $"Order: {Uid}; Total price: {TotalPrice}  ";
        }
    }
}
