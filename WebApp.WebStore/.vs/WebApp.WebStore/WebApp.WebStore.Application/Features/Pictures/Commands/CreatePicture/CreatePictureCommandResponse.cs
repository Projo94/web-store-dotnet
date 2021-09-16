using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Responses;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreatePictureCommandResponse : BaseResponse
    {
        public CreatePictureCommandResponse() : base()
        {

        }

        public OrderItemDto OrderItem { get; set; }
    }
}
