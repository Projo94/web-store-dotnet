using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApp.WebStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid?>
    {
        public CreateProductCommand()
        {
            Uid = Guid.NewGuid();
        }

        public Guid Uid { get; private set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int BrandTypeEID { get; set; }


        public List<PictureForCreationDto> listOfPictures { get; set; }

        public List<SizeTypeDto> listOfSizeTypes { get; set; }

        public List<CategoryDto> listOfCategories { get; set; }

        public override string ToString()
        {
            return $"Product caption: {Caption}; Price: {Price}; Description: {Description}";
        }


    }
}
