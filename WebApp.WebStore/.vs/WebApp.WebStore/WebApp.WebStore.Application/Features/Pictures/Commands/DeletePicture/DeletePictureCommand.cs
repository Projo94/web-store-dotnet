using MediatR;
using System;

namespace WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeletePictureCommand : IRequest
    {
        public int PictureId { get; set; }

    }
}
