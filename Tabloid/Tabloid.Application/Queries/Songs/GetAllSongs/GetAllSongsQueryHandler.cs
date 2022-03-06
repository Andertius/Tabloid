using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Songs.GetAllSongs
{
    internal class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAll();

            return result
                .Select(s => _mapper.Map<SongDto>(s))
                .ToArray();
        }
    }
}
