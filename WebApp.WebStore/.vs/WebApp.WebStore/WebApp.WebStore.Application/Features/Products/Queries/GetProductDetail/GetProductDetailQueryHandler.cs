using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Features.Products.Queries.GetProductList;
using WebApp.WebStore.Domain.Entities;
using WebStoreAPI.Models;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {


        private readonly IAsyncRepository<Product> _productRepository;

        private readonly IPictureRepository _pictureRepository;

        private readonly ISizeTypeRepository _sizeTypeRepository;

        private readonly ICategoryRepository _categoryRepository;


        private readonly IMapper _mapper;


        public GetProductDetailQueryHandler(IAsyncRepository<Product> productRepository, IMapper mapper, IPictureRepository pictureRepository, ISizeTypeRepository sizeTypeRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;

            _mapper = mapper;
            _pictureRepository = pictureRepository;
            _sizeTypeRepository = sizeTypeRepository;
            _categoryRepository = categoryRepository;
        }


        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id);

            var productToReturn = _mapper.Map<ProductDetailVm>(product);



            var pictureEntities = await _pictureRepository.GetPicturesForProduct(product.Uid);

            foreach (var pic in pictureEntities)
            {
                var pictureDto = _mapper.Map<PictureDto>(pic);

                productToReturn.Pictures.Add(pictureDto);
            }



            var sizeTypeEntities = await _sizeTypeRepository.GetProductSizeTypes(product.Uid);


            foreach (var st in sizeTypeEntities)
            {
                var sizeTypeDto = _mapper.Map<SizeTypeToReturnDto>(st);

                productToReturn.SizeTypes.Add(sizeTypeDto);
            }


            var categoryEntities = await _categoryRepository.GetProductCategories(product.Uid);


            foreach (var c in categoryEntities)
            {
                var categoryDto = _mapper.Map<CategoryToReturnDto>(c);

                productToReturn.Categories.Add(categoryDto);
            }






            return productToReturn;
        }
    }
}
