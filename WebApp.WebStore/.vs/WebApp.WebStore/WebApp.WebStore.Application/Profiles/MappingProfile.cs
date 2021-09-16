using AutoMapper;
using WebApp.WebStore.Application.Features.Brands.Queries.GetBrandList;
using WebApp.WebStore.Application.Features.Categories.Queries.GetCategoryList;
using WebApp.WebStore.Application.Features.Orders;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder;
using WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder.DTOs;
using WebApp.WebStore.Application.Features.Pictures.Queries.GetPictureDetail;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductDetail;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;
using WebApp.WebStore.Application.Features.SizeTypes.Queries.GetSizeTypeList;
using WebApp.WebStore.Domain.Entities;
using WebStoreAPI.Models;

namespace WebApp.WebStore.Application.Profiles
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderListVm>().ReverseMap();

            CreateMap<Order, CreateOrderCommand>().ReverseMap();

            CreateMap<Product, ProductListVm>().ReverseMap();

            CreateMap<Product, ProductDetailVm>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();

            // CreateMap<Product, ProductListVm>().ReverseMap();

            CreateMap<Picture, PictureForCreationDto>().ReverseMap();

            CreateMap<UpdateProductCommand, Product>().ReverseMap();

            CreateMap<PictureForCreationDto, Picture>().ReverseMap();

            CreateMap<CreateOrderCommand, Order>().ReverseMap();

            CreateMap<ProductCategory, CategoryToReturnDto>().ReverseMap();

            CreateMap<ProductSizeType, SizeTypeToReturnDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemForCreationDto>().ReverseMap();

            CreateMap<BrandType, BrandListVm>().ReverseMap();


            CreateMap<Picture, PictureVm>().ReverseMap();

            CreateMap<Picture, PictureDto>().ReverseMap();

            CreateMap<Category, CategoryListVm>().ReverseMap();

            CreateMap<Category, CategoryToReturnDto>().ReverseMap();

            CreateMap<SizeType, SizeTypeListVm>().ReverseMap();

            CreateMap<SizeType, SizeTypeToReturnDto>().ReverseMap();

        }

    }
}
