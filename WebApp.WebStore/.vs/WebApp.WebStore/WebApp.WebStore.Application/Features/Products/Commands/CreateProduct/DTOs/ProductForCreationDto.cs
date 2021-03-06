using System;
using System.Collections.Generic;

namespace WebApp.WebStore.Application.Features.Products.Commands.CreateProduct
{
    public class ProductForCreationDto
    {

        public ProductForCreationDto()
        {
            Uid = Guid.NewGuid();
        }

        public Guid Uid { get; private set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string BrandTypeEID { get; set; }


        public List<PictureForCreationDto> listOfPictures { get; set; }

        public List<SizeTypeDto> listOfSizeTypes { get; set; }

        public List<CategoryDto> listOfCategories { get; set; }

    }
}
