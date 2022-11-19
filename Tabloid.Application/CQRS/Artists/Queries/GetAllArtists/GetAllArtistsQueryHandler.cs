using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.GetAllArtists
{
    internal class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, ArtistDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllArtistsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
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
