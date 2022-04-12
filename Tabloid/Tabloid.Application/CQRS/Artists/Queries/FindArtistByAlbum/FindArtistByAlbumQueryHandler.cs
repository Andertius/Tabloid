using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistByAlbum
{
    internal class FindArtistByAlbumQueryHandler : IRequestHandler<FindArtistByAlbumQuery, ArtistDto>
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
                .FindById(request.Id);

            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindArtistByAlbum(album);

            return _mapper.Map<ArtistDto>(result);
        }
    }
}
