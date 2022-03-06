using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Albums.AddAlbum
{
    public class AddAlbumCommandHandler : IRequestHandler<AddAlbumCommand, CommandResponse<AlbumDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddAlbumCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<AlbumDto>> Handle(AddAlbumCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IAlbumRepository>();
            var entity = _mapper.Map<Album>(request.Album);

            if ((await repository
                .GetAll())
                .All(x => x.Name != entity.Name && x.ArtistId != entity.ArtistId))
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<AlbumDto>(_mapper.Map<AlbumDto>(entity));
            }

            return new CommandResponse<AlbumDto>(
                result: CommandResult.Failure,
                errorMessage: "The album already exists");
        }
    }
}
