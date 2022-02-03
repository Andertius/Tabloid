using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Queries.Genres.GetAllMetalGenres
{
    public class GetAllMetalGenresQueryHandler : IRequestHandler<GetAllMetalGenresQuery, GenreDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMetalGenresQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto[]> Handle(GetAllMetalGenresQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetAllMetalGenres();

            return result.Select(genre => _mapper.Map<GenreDto>(genre)).ToArray();
        }
    }
}
