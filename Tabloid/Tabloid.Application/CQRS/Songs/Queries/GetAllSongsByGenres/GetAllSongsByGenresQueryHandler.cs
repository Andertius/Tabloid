using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByGenres
{
    internal class GetAllSongsByGenresQueryHandler : IRequestHandler<GetAllSongsByGenresQuery, SongDto[]>
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
            var genres = (await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetAll())
                .Where(x => request.Ids.Contains(x.Id));

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByGenres(genres);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
