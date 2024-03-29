﻿using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Genres.Queries.GetAllGenres
{
    internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, GenreDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllGenresQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GenreDto[]> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetAll();

            return result
                .Select(x => _mapper.Map<GenreDto>(x))
                .ToArray();
        }
    }
}
