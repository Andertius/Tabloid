using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Tunings.Commands.DeleteTuning
{
    internal class DeleteTuningCommandHandler : IRequestHandler<DeleteTuningCommand, CommandResponse<GuitarTuningDto>>
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
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                await _unitOfWork.Save();
                
                return new CommandResponse<GuitarTuningDto>(_mapper.Map<GuitarTuningDto>(entity));
            }

            return new CommandResponse<GuitarTuningDto>(
                _mapper.Map<GuitarTuningDto>(entity),
                CommandResult.NotFound,
                "The tuning could not be found");
        }
    }
}
