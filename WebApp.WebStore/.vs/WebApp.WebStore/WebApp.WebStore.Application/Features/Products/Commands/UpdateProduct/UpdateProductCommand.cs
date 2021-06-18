using MediatR;
using System;
using System.Collections.Generic;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;

namespace WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int BrandTypeEID { get; set; }

        public List<SizeTypeDto> listOfSizeTypes { get; set; }

        public List<CategoryDto> listOfCategories { get; set; }



    }
}
