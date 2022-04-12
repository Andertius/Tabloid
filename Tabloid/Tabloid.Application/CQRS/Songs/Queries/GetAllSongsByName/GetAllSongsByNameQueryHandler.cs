using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByName
{
    internal class GetAllSongsByNameQueryHandler : IRequestHandler<GetAllSongsByNameQuery, SongDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSongsByNameQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SongDto[]> Handle(GetAllSongsByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<ISongRepository>()
                .GetAllSongsByName(request.Name);

            return result
                .Select(x => _mapper.Map<SongDto>(x))
                .ToArray();
        }
    }
}
