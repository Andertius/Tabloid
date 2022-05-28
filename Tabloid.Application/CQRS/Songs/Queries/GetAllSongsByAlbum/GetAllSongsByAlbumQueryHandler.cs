using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByAlbum
{
    internal class GetAllSongsByAlbumQueryHandler : IRequestHandler<GetAllSongsByAlbumQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByAlbumQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByAlbumQuery request, CancellationToken cancellationToken)
        {
            var album = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindById(request.Id);

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByAlbum(album);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
