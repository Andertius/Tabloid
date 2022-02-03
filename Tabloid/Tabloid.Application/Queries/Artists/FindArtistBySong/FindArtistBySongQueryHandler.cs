using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Artists.FindArtistBySong
{
    public class FindArtistBySongQueryHandler : IRequestHandler<FindArtistBySongQuery, ArtistDto>
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

        public async Task<ArtistDto> Handle(FindArtistBySongQuery request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork
                .GetRepository<ISongRepository>()
                .FindById(request.Song.Id);

            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindArtistBySong(song);

            return _mapper.Map<ArtistDto>(result);
        }
    }
}
