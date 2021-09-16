using MediatR;
using System;
using System.Collections.Generic;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Pictures.Commands.CreatePicture
{
    public class CreatePictureCommand : IRequest<List<Picture>>// returning value, when it is created, return a guid of newly created order
    {
        public Guid ProductID { get; set; }

        public List<PictureForCreationDto> listOfPictures { get; set; }


        public override string ToString()
        {
            return $"Picture: {ProductID} ";
        }
    }
}
