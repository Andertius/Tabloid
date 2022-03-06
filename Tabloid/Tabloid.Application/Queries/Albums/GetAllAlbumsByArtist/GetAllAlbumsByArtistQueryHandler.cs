using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Albums.GetAllAlbumsByArtist
{
    internal class GetAllAlbumsByArtistQueryHandler : IRequestHandler<GetAllAlbumsByArtistQuery, AlbumDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAlbumsByArtistQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumDto[]> Handle(GetAllAlbumsByArtistQuery request, CancellationToken cancellationToken)
        {
            var artist = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindById(request.Artist.Id);

            var result = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .GetAllAlbumsByArtist(artist);

            return result
                .Select(album => _mapper.Map<AlbumDto>(album))
                .ToArray();
        }
    }
}
