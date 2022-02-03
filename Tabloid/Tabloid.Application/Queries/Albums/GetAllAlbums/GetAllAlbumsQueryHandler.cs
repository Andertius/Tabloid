﻿using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Albums.GetAllAlbums
{
    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, AlbumDto[]>
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
                .GetAll(include: src => src.Include(x => x.Artist));

            return result
                .Select(album => _mapper.Map<AlbumDto>(album))
                .ToArray();
        }
    }
}
