using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.FindAlbumById;

internal class FindAlbumByIdQueryHandler : IRequestHandler<FindAlbumByIdQuery, AlbumDto?>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public FindAlbumByIdQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AlbumDto?> Handle(FindAlbumByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork
            .GetRepository<IAlbumRepository>()
            .FindById(request.Id);

        return _mapper.Map<AlbumDto?>(entity);
    }
}
