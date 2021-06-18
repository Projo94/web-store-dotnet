using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Api.Controllers;
using WebApp.WebStore.Application.Features.Orders;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder;

namespace WebApp.WebStore.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {

        //private readonly IMediator _mediator;
        //public OrderController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}


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




    }
}
