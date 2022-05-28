using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Tabs.Commands.UpdateTab
{
    internal class UpdateTabCommandHandler : IRequestHandler<UpdateTabCommand, CommandResponse<TabDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTabCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TabDto>> Handle(UpdateTabCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ITabRepository>();
            var entity = _mapper.Map<Tab>(request.Tab);

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<TabDto>(_mapper.Map<TabDto>(entity));
            }

            return new CommandResponse<TabDto>(
                _mapper.Map<TabDto>(entity),
                CommandResult.NotFound,
                "The tab could not be found");
        }
    }
}
