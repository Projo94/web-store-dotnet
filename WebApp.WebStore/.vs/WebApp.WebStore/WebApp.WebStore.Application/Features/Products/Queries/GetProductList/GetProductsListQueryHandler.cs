using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;
using WebStoreAPI.Models;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductListVm>>
    {

        private readonly IAsyncRepository<Product> _productRepository;

        private readonly IPictureRepository _pictureRepository;

        private readonly ISizeTypeRepository _sizeTypeRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;


        public GetProductsListQueryHandler(IAsyncRepository<Product> productRepository, IPictureRepository pictureRepository, IMapper mapper, ISizeTypeRepository sizeTypeRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _pictureRepository = pictureRepository;
            _sizeTypeRepository = sizeTypeRepository;
            _categoryRepository = categoryRepository;

            _mapper = mapper;

        }


        public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);


            var results = new List<ProductListVm>();

            foreach (var productEntity in allProducts)
            {

                var productDto = _mapper.Map<ProductListVm>(productEntity);


                var pictureEntities = await _pictureRepository.GetPicturesForProduct(productEntity.Uid);

                foreach (var pic in pictureEntities)
                {
                    var pictureDto = _mapper.Map<PictureDto>(pic);

                    productDto.Pictures.Add(pictureDto);
                }



                var sizeTypeEntities = await _sizeTypeRepository.GetProductSizeTypes(productEntity.Uid);


                foreach (var st in sizeTypeEntities)
                {
                    var sizeTypeDto = _mapper.Map<SizeTypeToReturnDto>(st);

                    productDto.SizeTypes.Add(sizeTypeDto);
                }


                var categoryEntities = await _categoryRepository.GetProductCategories(productEntity.Uid);


                foreach (var c in categoryEntities)
                {
                    var categoryDto = _mapper.Map<CategoryToReturnDto>(c);

                    productDto.Categories.Add(categoryDto);
                }

                results.Add(productDto);



            }

            return results;
        }
    }
}
