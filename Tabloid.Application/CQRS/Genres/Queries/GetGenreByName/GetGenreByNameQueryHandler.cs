using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.GetGenreByName
{
    internal class GetGenreByNameQueryHandler : IRequestHandler<GetGenreByNameQuery, GenreDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreByNameQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto> Handle(GetGenreByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .FindGenreByName(request.Name);

            return _mapper.Map<GenreDto>(result);
        }
    }
}
