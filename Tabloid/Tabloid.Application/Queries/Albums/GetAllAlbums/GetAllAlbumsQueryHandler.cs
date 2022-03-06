using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Albums.GetAllAlbums
{
    internal class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, AlbumDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAlbumsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlbumDto[]> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .GetAll();

            return result
                .Select(album => _mapper.Map<AlbumDto>(album))
                .ToArray();
        }
    }
}
