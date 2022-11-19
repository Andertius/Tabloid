using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistById
{
    internal class FindArtistByIdQueryHandler : IRequestHandler<FindArtistByIdQuery, ArtistDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public FindArtistByIdQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Handle(FindArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork
                .GetRepository<IArtistRepository>()
                .FindById(request.Id);

            return _mapper.Map<ArtistDto>(entity);
        }
    }
}
