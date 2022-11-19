using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Tunings.Commands.UpdateTuning;

internal class UpdateTuningCommandHandler : IRequestHandler<UpdateTuningCommand, CommandResponse<TuningDto>>
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

    public async Task<CommandResponse<TuningDto>> Handle(UpdateTuningCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ITuningRepository>();
        var entity = _mapper.Map<Tuning>(request.Tuning);

        if (await repository.Contains(entity))
        {
            repository.Update(entity);
            await _unitOfWork.Save();

            return new CommandResponse<TuningDto>(_mapper.Map<TuningDto>(entity));
        }

        return new CommandResponse<TuningDto>(
            _mapper.Map<TuningDto>(entity),
            CommandResult.NotFound,
            "The tuning could not be found");
    }
}
