using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Artists.FindArtistByAlbum
{
    public class FindArtistByAlbumQueryHandler : IRequestHandler<FindArtistByAlbumQuery, ArtistDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public FindArtistByAlbumQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Handle(FindArtistByAlbumQuery request, CancellationToken cancellationToken)
        {
            var album = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindById(request.Album.Id);

            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindArtistByAlbum(album);

            return _mapper.Map<ArtistDto>(result);
        }
    }
}
