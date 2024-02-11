using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTuning;

internal class GetAllSongsByTuningQueryHandler : IRequestHandler<GetAllSongsByTuningQuery, SongDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSongsByTuningQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SongDto[]> Handle(GetAllSongsByTuningQuery request, CancellationToken cancellationToken)
    {
        var tuning = await _unitOfWork
            .GetRepository<ITuningRepository>()
            .FindById(request.Id);

        if (tuning is null)
        {
            return Array.Empty<SongDto>();
        }

        var result = await _unitOfWork
            .GetRepository<ISongRepository>()
            .GetAllSongsByTuning(tuning);

        return result
            .Select(x => _mapper.Map<SongDto>(x))
            .ToArray();
    }
}
