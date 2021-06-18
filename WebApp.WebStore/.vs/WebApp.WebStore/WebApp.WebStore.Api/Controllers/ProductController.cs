using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Application.Features.Products.Commands.DeleteOrder;
using WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;

namespace WebApp.WebStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var dtos = await _mediator.Send(new GetProductsListQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);

            if (response is not null)
                return Ok(response);

            return BadRequest();
        }



        [HttpPut(Name = "UpdateProductCommand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }



        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };

            await _mediator.Send(deleteProductCommand);

            return NoContent();

        }








    }
}
