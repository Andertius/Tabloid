using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Tunings.Commands.DeleteTuning
{
    internal class DeleteTuningCommandHandler : IRequestHandler<DeleteTuningCommand, CommandResponse<TuningDto>>
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

        public async Task<CommandResponse<TuningDto>> Handle(DeleteTuningCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ITuningRepository>();
            var entity = await repository.FindById(request.Id);

            if (await repository.Contains(entity))
            {
                repository.Remove(entity);
                await _unitOfWork.Save();
                
                return new CommandResponse<TuningDto>(_mapper.Map<TuningDto>(entity));
            }

            return new CommandResponse<TuningDto>(
                _mapper.Map<TuningDto>(entity),
                CommandResult.NotFound,
                "The tuning could not be found");
        }
    }
}
