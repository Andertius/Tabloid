using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Albums.Commands.DeleteAlbum;

internal class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand, CommandResponse<AlbumDto>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteAlbumCommandHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<AlbumDto>> Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<IAlbumRepository>();
        var entity = await repository.FindById(request.Id);

        if (await repository.Contains(entity))
        {
            repository.Remove(entity);
            await _unitOfWork.Save();

            return new CommandResponse<AlbumDto>(_mapper.Map<AlbumDto>(entity));
        }

        return new CommandResponse<AlbumDto>(
            _mapper.Map<AlbumDto>(entity),
            CommandResult.NotFound,
            "The album could not be found");
    }
}
