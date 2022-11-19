using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.FindGenreById;

internal class FindGenreByIdQueryHandler : IRequestHandler<FindGenreByIdQuery, GenreDto?>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public FindGenreByIdQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GenreDto?> Handle(FindGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork
            .GetRepository<IGenreRepository>()
            .FindById(request.Id);

        return _mapper.Map<GenreDto?>(entity);
    }
}
