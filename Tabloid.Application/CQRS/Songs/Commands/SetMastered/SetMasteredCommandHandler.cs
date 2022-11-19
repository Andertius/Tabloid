using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.SetMastered
{
    internal class SetMasteredCommandHandler : IRequestHandler<SetMasteredCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public SetMasteredCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(SetMasteredCommand request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork
                .GetRepository<ISongRepository>()
                .FindById(request.SongId);

            song.FullyMastered = request.IsMastered;

            await _unitOfWork.Save();

            return new CommandResponse<SongDto>(_mapper.Map<SongDto>(song));
        }
    }
}
