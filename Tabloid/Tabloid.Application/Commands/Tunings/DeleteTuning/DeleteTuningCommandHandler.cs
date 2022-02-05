using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Commands.Tunings.DeleteTuning
{
    public class DeleteTuningCommandHandler : IRequestHandler<DeleteTuningCommand, CommandResponse<GuitarTuningDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTuningCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<GuitarTuningDto>> Handle(DeleteTuningCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGuitarTuningRepository>();
            var entity = _mapper.Map<GuitarTuning>(request.Tuning);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                return new CommandResponse<GuitarTuningDto>(_mapper.Map<GuitarTuningDto>(entity));
            }

            return new CommandResponse<GuitarTuningDto>(
                _mapper.Map<GuitarTuningDto>(entity),
                CommandResult.Failure,
                "The tuning could not be found");
        }
    }
}
