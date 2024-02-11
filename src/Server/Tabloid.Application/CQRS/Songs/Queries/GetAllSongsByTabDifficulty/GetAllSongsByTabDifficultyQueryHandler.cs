using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTabDifficulty;

internal class GetAllSongsByTabDifficultyQueryHandler : IRequestHandler<GetAllSongsByTabDifficultyQuery, SongDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSongsByTabDifficultyQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SongDto[]> Handle(GetAllSongsByTabDifficultyQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork
            .GetRepository<ISongRepository>()
            .GetAllSongsByTabDifficulty(request.Difficulty);

        return result
            .Select(x => _mapper.Map<SongDto>(x))
            .ToArray();
    }
}
