using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Songs.Commands.UpdateSong
{
    internal class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSongCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ISongRepository>();
            var entity = _mapper.Map<Song>(request.Song);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<SongDto>(_mapper.Map<SongDto>(entity));
            }

            return new CommandResponse<SongDto>(
                _mapper.Map<SongDto>(entity),
                CommandResult.NotFound,
                "The song could not be found");
        }
    }
}
