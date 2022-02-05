using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Application.Commands.Tunings.UpdateTuning
{
    public class UpdateTuningCommandHandler : IRequestHandler<UpdateTuningCommand, CommandResponse<GuitarTuningDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTuningCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<GuitarTuningDto>> Handle(UpdateTuningCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGuitarTuningRepository>();
            var entity = _mapper.Map<GuitarTuning>(request.Tuning);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                return new CommandResponse<GuitarTuningDto>(_mapper.Map<GuitarTuningDto>(entity));
            }

            return new CommandResponse<GuitarTuningDto>(
                _mapper.Map<GuitarTuningDto>(entity),
                CommandResult.Failure,
                "The tuning could not be found");
        }
    }
}
