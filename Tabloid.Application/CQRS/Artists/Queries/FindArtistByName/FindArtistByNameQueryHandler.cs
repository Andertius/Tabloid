using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistByName
{
    internal class FindArtistByNameQueryHandler : IRequestHandler<FindArtistByNameQuery, ArtistDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public FindArtistByNameQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Handle(FindArtistByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindArtistByName(request.Name);

            return _mapper.Map<ArtistDto>(result);
        }
    }
}
