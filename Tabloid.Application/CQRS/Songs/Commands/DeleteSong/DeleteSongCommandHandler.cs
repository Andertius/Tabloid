using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Songs.Commands.DeleteSong
{
    internal class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSongCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ISongRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
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
