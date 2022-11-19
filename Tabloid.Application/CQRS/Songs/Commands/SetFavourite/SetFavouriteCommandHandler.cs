using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.SetFavourite
{
    internal class SetMasteredCommandHandler : IRequestHandler<SetFavouriteCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public SetMasteredCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(SetFavouriteCommand request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork
                .GetRepository<ISongRepository>()
                .FindById(request.SongId);

            song.IsFavourite = request.IsFavourite;

            await _unitOfWork.Save();

            return new CommandResponse<SongDto>(_mapper.Map<SongDto>(song));
        }
    }
}
