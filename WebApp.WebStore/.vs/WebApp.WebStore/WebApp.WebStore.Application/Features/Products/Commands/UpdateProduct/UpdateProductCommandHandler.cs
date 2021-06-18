using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Exceptions;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _unitOfWork.ProductRepository.GetByIdAsync(request.Uid);

            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.Uid);
            }

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {

                    _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

                    await _unitOfWork.ProductRepository.UpdateAsync(productToUpdate);



                    var listProductCategory = _unitOfWork.ProductCategoryRepository.GetProductCategories(request.Uid);

                    foreach (var pc in listProductCategory)
                    {
                        var match = request.listOfCategories.Where(p => p.CategoryID == pc.CategoryID).FirstOrDefault();

                        //delete product category that not exists in updated list 
                        if (match is null)
                            await _unitOfWork.ProductCategoryRepository.DeleteAsync(pc);
                        else
                            request.listOfCategories.Remove(match);

                    }


                    var listProductSizeType = _unitOfWork.ProductSizeTypeRepository.GetProductSizeTypes(request.Uid);

                    foreach (var ps in listProductSizeType)
                    {
                        var match = request.listOfSizeTypes.Where(p => p.SizeTypeEID == ps.SizeTypeID).FirstOrDefault();

                        //delete product size type that not exists in updated list 
                        if (match is null)
                            await _unitOfWork.ProductSizeTypeRepository.DeleteAsync(ps);
                        else
                            request.listOfSizeTypes.Remove(match);

                    }


                    var listOfProductCategories = new List<ProductCategory>();


                    foreach (var item in request.listOfCategories)
                    {
                        var pc = new ProductCategory(request.Uid, item.CategoryID);

                        listOfProductCategories.Add(pc);
                    }



                    var listOfProductSizeTypes = new List<ProductSizeType>();


                    foreach (var item in request.listOfSizeTypes)
                    {
                        var pc = new ProductSizeType(request.Uid, item.SizeTypeEID);

                        listOfProductSizeTypes.Add(pc);
                    }


                    await _unitOfWork.ProductCategoryRepository.AddRange(listOfProductCategories);

                    await _unitOfWork.SaveChangesAsync();


                    await _unitOfWork.ProductSizeTypeRepository.AddRange(listOfProductSizeTypes);
                    await _unitOfWork.SaveChangesAsync();


                    await transaction.CommitAsync();



                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }

                return Unit.Value;

            }
        }




    }
}
