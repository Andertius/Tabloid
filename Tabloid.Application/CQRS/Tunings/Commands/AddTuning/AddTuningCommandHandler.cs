using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Tunings.Commands.AddTuning;

internal class AddTuningCommandHandler : IRequestHandler<AddTuningCommand, CommandResponse<TuningDto>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public AddTuningCommandHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<TuningDto>> Handle(AddTuningCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ITuningRepository>();
        var entity = _mapper.Map<Tuning>(request.Tuning);

        if (!await repository.HasKey(request.Tuning.Id) &&
            (await repository
                .GetAll())
                .All(x => x.Name != entity.Name && x.Strings != entity.Strings))
        {
            await repository.Insert(entity);
            await _unitOfWork.Save();

            return new CommandResponse<TuningDto>(_mapper.Map<TuningDto>(entity));
        }

        return new CommandResponse<TuningDto>(
            result: CommandResult.NotFound,
            errorMessage: "The tuning already exists");
    }
}
