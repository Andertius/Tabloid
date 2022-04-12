using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTuning
{
    internal class GetAllSongsByTuningQueryHandler : IRequestHandler<GetAllSongsByTuningQuery, SongDto[]>
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
            var tuning = await _unitOfWork
                .GetRepository<IGuitarTuningRepository>()
                .FindById(request.Id);

            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByTuning(tuning);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
