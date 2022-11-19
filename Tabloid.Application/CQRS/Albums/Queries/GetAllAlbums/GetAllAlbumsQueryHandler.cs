using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.GetAllAlbums
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
