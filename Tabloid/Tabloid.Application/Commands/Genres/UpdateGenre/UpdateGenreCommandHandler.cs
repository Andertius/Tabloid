using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Genres.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, CommandResponse<GenreDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<GenreDto>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGenreRepository>();
            var entity = _mapper.Map<Genre>(request.Genre);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<GenreDto>(_mapper.Map<GenreDto>(entity));
            }

            return new CommandResponse<GenreDto>(
                _mapper.Map<GenreDto>(entity),
                CommandResult.NotFound,
                "The genre could not be found");
        }
    }
}
