using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Albums.Commands.UpdateAlbum;

internal class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, CommandResponse<AlbumDto>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAlbumCommandHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<AlbumDto>> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<IAlbumRepository>();
        var entity = _mapper.Map<Album>(request.Album);

        if (await repository.Contains(entity))
        {
            repository.Update(entity);
            await _unitOfWork.Save();

            return new CommandResponse<AlbumDto>(_mapper.Map<AlbumDto>(entity));
        }

        return new CommandResponse<AlbumDto>(
            _mapper.Map<AlbumDto>(entity),
            CommandResult.NotFound,
            "The album could not be found");
    }
}
