﻿using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistBySong
{
    internal class FindArtistBySongQueryHandler : IRequestHandler<FindArtistBySongQuery, ArtistDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public FindArtistBySongQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Handle(FindArtistBySongQuery request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork
                .GetRepository<ISongRepository>()
                .FindById(request.Id);

            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindArtistBySong(song);

            return _mapper.Map<ArtistDto>(result);
        }
    }
}
