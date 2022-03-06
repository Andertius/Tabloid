using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Albums.GetAlbumBySong
{
    internal class GetAlbumBySongQueryHandler : IRequestHandler<GetAlbumBySongQuery, AlbumDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAlbumBySongQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumDto> Handle(GetAlbumBySongQuery request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork
                .GetRepository<ISongRepository>()
                .FindById(request.Song.Id);

            var result = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindAlbumBySong(song);

            return _mapper.Map<AlbumDto>(result);
        }
    }
}
