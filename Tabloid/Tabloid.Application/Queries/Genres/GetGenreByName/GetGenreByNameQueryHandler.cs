using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Genres.GetGenreByName
{
    public class GetGenreByNameQueryHandler : IRequestHandler<GetGenreByNameQuery, GenreDto>
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
