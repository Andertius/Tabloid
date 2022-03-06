using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Artists.UpdateArtist
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, CommandResponse<ArtistDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateArtistCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<ArtistDto>> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IArtistRepository>();
            var entity = _mapper.Map<Artist>(request.Artist);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
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
