using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Pictures.Commands.UpdatePicture
{
    public class UpdatePictureCommandHandler : IRequestHandler<UpdatePictureCommand>
    {
        private readonly IAsyncRepository<Picture> _pictureRepository;
        private readonly IMapper _mapper;


        public UpdatePictureCommandHandler(IMapper mapper, IAsyncRepository<Picture> pictureRepository)
        {
            _mapper = mapper;
            _pictureRepository = pictureRepository;

        }


        public async Task<Unit> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
        {
            var pictureToUpdate = await _pictureRepository.GetByIdIntAsync(request.PictureID);
            _mapper.Map(request, pictureToUpdate, typeof(UpdatePictureCommand), typeof(Picture));

            await _pictureRepository.UpdateAsync(pictureToUpdate);

            return Unit.Value;


        }
    }
}
