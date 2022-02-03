using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Artists.GetAllArtists
{
    public class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, ArtistDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllArtistsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDto[]> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<ArtistDto>(x))
                .ToArray();
        }
    }
}
