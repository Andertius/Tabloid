using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Artists.DeleteArtist
{
    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand, CommandResponse<ArtistDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteArtistCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<ArtistDto>> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IArtistRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                await _unitOfWork.Save();

                return new CommandResponse<ArtistDto>(_mapper.Map<ArtistDto>(entity));
            }

            return new CommandResponse<ArtistDto>(
                _mapper.Map<ArtistDto>(entity),
                CommandResult.NotFound,
                "The artist could not be found");
        }
    }
}
