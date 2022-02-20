using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByArtists
{
    public class GetAllSongsByArtistsQueryHandler : IRequestHandler<GetAllSongsByArtistsQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByArtistsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByArtistsQuery request, CancellationToken cancellationToken)
        {
            var artists = request
                .Artists
                .Select(x => _mapper.Map<Artist>(x))
                .ToList();

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByArtists(artists);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
