using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Genres.GetEveryOtherGenre
{
    public class GetEveryOtherGenreQueryHandler : IRequestHandler<GetEveryOtherGenreQuery, GenreDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetEveryOtherGenreQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto[]> Handle(GetEveryOtherGenreQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetEveryOtherGenre();

            return result.Select(x => _mapper.Map<GenreDto>(x)).ToArray();
        }
    }
}
