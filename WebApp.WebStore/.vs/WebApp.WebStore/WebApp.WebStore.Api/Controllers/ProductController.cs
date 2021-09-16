using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Features.Brands.Queries.GetBrandList;
using WebApp.WebStore.Application.Features.Categories.Queries.GetCategoryList;
using WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder;
using WebApp.WebStore.Application.Features.Pictures.Commands.CreatePicture;
using WebApp.WebStore.Application.Features.Pictures.Queries.GetPictureDetail;
using WebApp.WebStore.Application.Features.Pictures.Queries.GetPicturesList;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Application.Features.Products.Commands.DeleteOrder;
using WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct;
using WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductDetail;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;
using WebApp.WebStore.Application.Features.SizeTypes.Queries.GetSizeTypeList;

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


        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDetailVm>> GetProduct(Guid id)
        {
            var dtos = await _mediator.Send(new GetProductDetailQuery() { id = id });
            return Ok(dtos);
        }






        [HttpPost("CreateProduct", Name = "AddProduct")]
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




        [HttpGet("GetAllPicturesForProduct", Name = "GetAllPicturesForProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PictureVm>>> GetPicturesForProduct(Guid productId)
        {
            var dtos = await _mediator.Send(new GetPicturesForProductQuery() { ProductId = productId });
            return Ok(dtos);
        }


        [HttpGet("allbrandtypes", Name = "GetAllBrandTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BrandListVm>>> GetAllBrandTypes()
        {
            var dtos = await _mediator.Send(new GetBrandListQuery());
            return Ok(dtos);
        }

        [HttpGet("allcategories", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }


        [HttpGet("allsizetypes", Name = "GetAllSizeTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SizeTypeListVm>>> GetAllSizeTypes()
        {
            var dtos = await _mediator.Send(new GetSizeTypeListQuery());
            return Ok(dtos);
        }



        //[HttpPut(Name = "UpdatePictureCommand")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> UpdatePictureForProduct([FromBody] UpdateProductCommand updateProductCommand)
        //{
        //    await _mediator.Send(updateProductCommand);
        //    return NoContent();
        //}



        [HttpDelete("picture/{id}", Name = "DeletePicture")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult<Guid>> DeletePictureForProduct(int id)
        {
            var deletePictureCommand = new DeletePictureCommand() { PictureId = id };

            await _mediator.Send(deletePictureCommand);

            return NoContent();

        }

        [HttpPost("createpicture", Name = "AddPicturesForProduct")]
        public async Task<ActionResult<List<PictureVm>>> AddPicturesForProduct([FromBody] CreatePictureCommand createPictureCommand)
        {
            var response = await _mediator.Send(createPictureCommand);

            if (response is not null)
                return Ok(response);

            return BadRequest();
        }


        [HttpPost("getbestbuyproducts", Name = "GetBestBuyProductsInLastMonthQuery")]
        public async Task<ActionResult<List<PictureVm>>> GetBestBuyProductsInLastMonth([FromBody] GetBestBuyProductsInLastMonthQuery getBestBuyProductsInLastMonthQuery)
        {
            var response = await _mediator.Send(getBestBuyProductsInLastMonthQuery);

            if (response is not null)
                return Ok(response);

            return BadRequest();
        }


    }
}











