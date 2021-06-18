using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>// returning value, when it is created, return a guid of newly created order
    {

        public int OrderID { get; set; }

        public Guid Uid { get; set; }

        public double TotalPrice { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }


        public override string ToString()
        {
            return $"Order: {OrderID}; Total price: {TotalPrice}  ";
        }
    }
}
