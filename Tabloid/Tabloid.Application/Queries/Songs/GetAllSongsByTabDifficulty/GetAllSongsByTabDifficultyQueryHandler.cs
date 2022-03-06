using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByTabDifficulty
{
    internal class GetAllSongsByTabDifficultyQueryHandler : IRequestHandler<GetAllSongsByTabDifficultyQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByTabDifficultyQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByTabDifficultyQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByTabDifficulty(request.Difficulty);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
