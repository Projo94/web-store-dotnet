using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Api.Controllers;
using WebApp.WebStore.Application.Features.Orders;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder;
using WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder;
using WebApp.WebStore.Application.Features.Orders.Commands.UpdateOrder;

namespace WebApp.WebStore.Api
{
    [EnableCors("Open")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        [Authorize]
        [HttpGet("all", Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderListVm>>> GetAllOrders()
        {
            var dtos = await Mediator.Send(new GetOrdersListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult<CreateOrderCommandResponse>> Create([FromBody] CreateOrderCommand createOrderCommand)
        {
            var response = await Mediator.Send(createOrderCommand);

            return Ok(response);
        }

        //[HttpGet("export", Name = "ExportEvents")]
        //public async Task<FileResult> ExportOrders()
        //{
        //    var fileDto = await Mediator.Send(new GetOrdersExportQuery());

        //    return File(fileDto.Data, fileDto.ContentType, fileDto.OrderExportFileName);
        //}


        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<Guid>> DeleteOrderForProduct(Guid id)
        {
            var deletePictureCommand = new DeleteOrderCommand() { OrderId = id };

            await Mediator.Send(deletePictureCommand);

            return NoContent();

        }



        [HttpPut(Name = "UpdateOrderCommand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePictureForProduct([FromBody] UpdateOrderCommand updateOrderCommand)
        {
            await Mediator.Send(updateOrderCommand);
            return NoContent();
        }





    }
}
