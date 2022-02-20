using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByTuning
{
    public class GetAllSongsByTuningQueryHandler : IRequestHandler<GetAllSongsByTuningQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByTuningQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByTuningQuery request, CancellationToken cancellationToken)
        {
            var tuning = _mapper.Map<GuitarTuning>(request.Tuning);

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByTuning(tuning);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
