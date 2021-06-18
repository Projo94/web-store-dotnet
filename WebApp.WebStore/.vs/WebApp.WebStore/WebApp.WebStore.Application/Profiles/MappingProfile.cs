using AutoMapper;
using WebApp.WebStore.Application.Features.Orders;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Profiles
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderListVm>().ReverseMap();

            CreateMap<Order, CreateOrderCommand>().ReverseMap();

            CreateMap<Product, ProductListVm>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Picture, PictureForCreationDto>().ReverseMap();

            CreateMap<UpdateProductCommand, Product>().ReverseMap();

        }

    }
}
