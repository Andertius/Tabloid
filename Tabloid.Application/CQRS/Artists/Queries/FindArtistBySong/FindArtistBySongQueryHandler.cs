using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistBySong;

internal class FindArtistBySongQueryHandler : IRequestHandler<FindArtistBySongQuery, ArtistDto?>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public FindArtistBySongQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ArtistDto?> Handle(FindArtistBySongQuery request, CancellationToken cancellationToken)
    {
        var song = await _unitOfWork
            .GetRepository<ISongRepository>()
            .FindById(request.Id);

        if (song is null)
        {
            return null;
        }

        var result = await _unitOfWork
            .GetRepository<IArtistRepository>()
            .FindArtistBySong(song);

        return _mapper.Map<ArtistDto>(result);
    }
}
