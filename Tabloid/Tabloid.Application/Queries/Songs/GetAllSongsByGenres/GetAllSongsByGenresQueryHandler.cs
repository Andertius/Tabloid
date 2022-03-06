using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByGenres
{
    public class GetAllSongsByGenresQueryHandler : IRequestHandler<GetAllSongsByGenresQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByGenresQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = request
                .Genres
                .Select(x => _mapper.Map<Genre>(x))
                .ToList();

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByGenres(genres);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
