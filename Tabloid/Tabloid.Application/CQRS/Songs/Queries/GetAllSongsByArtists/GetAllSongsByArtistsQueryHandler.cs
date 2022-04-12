using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByArtists
{
    internal class GetAllSongsByArtistsQueryHandler : IRequestHandler<GetAllSongsByArtistsQuery, SongDto[]>
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
            var artists = (await _unitOfWork
                .GetRepository<IArtistRepository>()
                .GetAll())
                .Where(x => request.Ids.Contains(x.Id));

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByArtists(artists);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
