using System;
using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class ProductListVm
    {

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int BrandTypeEID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public List<PictureDto> Pictures { get; set; } = new List<PictureDto>();

        public List<CategoryToReturnDto> Categories { get; set; } = new List<CategoryToReturnDto>();

        public List<SizeTypeToReturnDto> SizeTypes { get; set; } = new List<SizeTypeToReturnDto>();



    }
}
