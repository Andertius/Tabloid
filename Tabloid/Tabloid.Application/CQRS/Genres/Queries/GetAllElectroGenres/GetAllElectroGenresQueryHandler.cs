using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllElectroGenres
{
    internal class GetAllElectroGenresQueryHandler : IRequestHandler<GetAllElectroGenresQuery, GenreDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllElectroGenresQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto[]> Handle(GetAllElectroGenresQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetAllElectroGenres();

            return result.Select(x => _mapper.Map<GenreDto>(x)).ToArray();
        }
    }
}
