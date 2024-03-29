﻿using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.CQRS.Tunings.Commands.UpdateTuning
{
    internal class UpdateTuningCommandHandler : IRequestHandler<UpdateTuningCommand, CommandResponse<GuitarTuningDto>>
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
