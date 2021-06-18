using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateProductCommandHandler(IEmailService emailService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid?> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_unitOfWork.ProductRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);


            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var @product = _mapper.Map<Product>(request);

                    @product = await _unitOfWork.ProductRepository.AddAsync(@product);


                    // adding product category
                    var @productCategory = new ProductCategory();
                    @productCategory.ProductID = @product.Uid;

                    foreach (var cat in request.listOfCategories)
                    {
                        @productCategory.CategoryID = cat.CategoryID;
                        await _unitOfWork.ProductCategoryRepository.AddAsync(@productCategory);
                    }



                    // adding product size types
                    var @productSizeType = new ProductSizeType();
                    @productSizeType.ProductID = @product.Uid;

                    foreach (var st in request.listOfSizeTypes)
                    {
                        @productSizeType.SizeTypeID = st.SizeTypeEID;
                        await _unitOfWork.ProductSizeTypeRepository.AddAsync(@productSizeType);
                    }

                    //adding product pictures

                    foreach (var pic in request.listOfPictures)
                    {
                        var @picture = _mapper.Map<Picture>(pic);

                        @picture.ProductID = @product.Uid;

                        await _unitOfWork.PictureRepository.AddAsync(@picture);

                    }

                    transaction.Commit();

                    return @product.Uid;
                }

                catch (Exception ex)
                {
                    transaction.Rollback();

                    return null;
                }

            }



        }

    }
}
