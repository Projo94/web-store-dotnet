using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Application.Features.Pictures.Commands.CreatePicture;
using WebApp.WebStore.Application.Features.Products.Commands.CreateProduct;
using WebApp.WebStore.Application.Models.Mail;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.CreateOrder
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand, List<Picture>>
    {
        private readonly IAsyncRepository<Picture> _pictureRepository;
        private readonly IAsyncRepository<Product> _productRepository;

        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public CreatePictureCommandHandler(IMapper mapper, IPictureRepository pictureRepository, IAsyncRepository<Product> productRepository, IEmailService emailService = null)
        {
            _mapper = mapper;
            _pictureRepository = pictureRepository;
            _emailService = emailService;
            _productRepository = productRepository;
        }



        public async Task<List<Picture>> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreatePictureCommandValidator(_productRepository);
            //var validationResult = await validator.ValidateAsync(request);


            //if (validationResult.Errors.Count > 0)
            //    throw new Exceptions.ValidationException(validationResult);


            var @pictures = _mapper.Map<IEnumerable<PictureForCreationDto>, IEnumerable<Picture>>(request.listOfPictures).ToList();

            @pictures = @pictures.Select(c => { c.ProductID = request.ProductID; return c; }).ToList();

            await _pictureRepository.AddRange(@pictures);
            await _pictureRepository.SaveChangesAsync();


            var email = new Email()
            {
                To = "markoprojovic@gmail.com",
                Body = $"A new picture was created: {request}",
                Subject = "A new order was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged

            }


            return @pictures;

        }


    }
}
