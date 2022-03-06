using System;

using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Commands.Tunings.AddTuning
{
    public class AddTuningCommandHandler : IRequestHandler<AddTuningCommand, CommandResponse<GuitarTuningDto>>
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

        public async Task<CommandResponse<GuitarTuningDto>> Handle(AddTuningCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<IGuitarTuningRepository>();
            var entity = _mapper.Map<GuitarTuning>(request.Tuning);

            if ((await repository.GetAll()).All(x => x.Name != entity.Name && x.Tuning != entity.Tuning))
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<GuitarTuningDto>(_mapper.Map<GuitarTuningDto>(entity));
            }

            return new CommandResponse<GuitarTuningDto>(
                result: CommandResult.NotFound,
                errorMessage: "The tuning already exists");
        }
    }
}
