using System;
using System.Collections.Generic;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;
using WebStoreAPI.Models;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductDetail
{
    public class ProductDetailVm
    {

        public Guid Uid { get; set; }

        public string Caption { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int BrandTypeEID { get; set; }

        public List<PictureDto> Pictures { get; set; } = new List<PictureDto>();

        public List<CategoryToReturnDto> Categories { get; set; } = new List<CategoryToReturnDto>();

        public List<SizeTypeToReturnDto> SizeTypes { get; set; } = new List<SizeTypeToReturnDto>();


    }
}
