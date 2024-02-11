using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongs;

internal class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, SongDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSongsQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SongDto[]> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork
            .GetRepository<ISongRepository>()
            .GetAll();

        return result
            .Select(s => _mapper.Map<SongDto>(s))
            .ToArray();
    }
}
