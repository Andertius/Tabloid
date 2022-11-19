using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByArtist
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
                .FindById(request.Id);

            var result = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .GetAllAlbumsByArtist(artist);

            return result
                .Select(album => _mapper.Map<AlbumDto>(album))
                .ToArray();
        }
    }
}
