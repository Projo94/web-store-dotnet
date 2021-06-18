using MediatR;
using System;

namespace WebApp.WebStore.Application.Features.Products.Commands.DeleteOrder
{
    public class DeleteProductCommand : IRequest
    {
        public Guid ProductId { get; set; }

    }
}
