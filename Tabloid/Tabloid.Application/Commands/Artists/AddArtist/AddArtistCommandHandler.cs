using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Artists.AddArtist
{
    internal class AddArtistCommandHandler : IRequestHandler<AddArtistCommand, CommandResponse<ArtistDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddArtistCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<ArtistDto>> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IArtistRepository>();
            var entity = _mapper.Map<Artist>(request.Artist);

            if ((await repository
                .GetAll())
                .All(x => x.Name != entity.Name))
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<ArtistDto>(_mapper.Map<ArtistDto>(entity));
            }

            return new CommandResponse<ArtistDto>(
                result: CommandResult.Failure,
                errorMessage: "The artist already exists");
        }
    }
}
