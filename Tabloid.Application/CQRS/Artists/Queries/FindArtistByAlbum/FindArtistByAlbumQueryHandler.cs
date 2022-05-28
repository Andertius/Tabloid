using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

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
