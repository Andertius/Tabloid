using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Genres.Commands.DeleteGenre
{
    internal class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, CommandResponse<GenreDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGenreCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<GenreDto>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGenreRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
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
