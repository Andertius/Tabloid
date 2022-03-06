using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Songs.AddSong
{
    internal class AddSongCommandHandler : IRequestHandler<AddSongCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddSongCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ISongRepository>();
            var entity = _mapper.Map<Song>(request.Song);

            if (entity.Id == Guid.Empty)
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<SongDto>(_mapper.Map<SongDto>(entity));
            }

            return new CommandResponse<SongDto>(
                result: CommandResult.Failure,
                errorMessage: "The song already exists");
        }
    }
}
