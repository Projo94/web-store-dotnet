using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.WebStore.Application.Contracts.Persistence;
using WebApp.WebStore.Domain.Entities;

namespace WebApp.WebStore.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly IAsyncRepository<Picture> _pictureRepository;
        private readonly IMapper _mapper;

        public DeletePictureCommandHandler(IMapper mapper, IAsyncRepository<Picture> pictureRepository)
        {
            _mapper = mapper;
            _pictureRepository = pictureRepository;
        }

        public async Task<Unit> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {







            var pictureToDelete = await _pictureRepository.GetByIdIntAsync(request.PictureId);

            await _pictureRepository.DeleteAsync(pictureToDelete);

            return Unit.Value;
        }
    }
}
