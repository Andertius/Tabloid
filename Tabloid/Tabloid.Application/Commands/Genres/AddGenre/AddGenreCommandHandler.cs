using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Commands.Genres.AddGenre
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, CommandResponse<GenreDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddGenreCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<GenreDto>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGenreRepository>();
            var entity = _mapper.Map<Genre>(request.Genre);

            if ((await repository
                .GetAll())
                .All(x => x.Name != entity.Name))
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<GenreDto>(_mapper.Map<GenreDto>(entity));
            }

            return new CommandResponse<GenreDto>(
                result: CommandResult.Failure,
                errorMessage: "The genre already exists");
        }
    }
}
