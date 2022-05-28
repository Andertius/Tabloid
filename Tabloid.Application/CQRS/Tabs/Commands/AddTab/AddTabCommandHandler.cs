using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Tabs.Commands.AddTab
{
    public class AddTabCommandHandler : IRequestHandler<AddTabCommand, CommandResponse<TabDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddTabCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<TabDto>> Handle(AddTabCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ITabRepository>();
            var entity = _mapper.Map<Tab>(request.Tab);

            if (entity.Id == Guid.Empty)
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                return new CommandResponse<TabDto>(_mapper.Map<TabDto>(entity));
            }

            return new CommandResponse<TabDto>(
                result: CommandResult.Failure,
                errorMessage: "The tab already exists");
        }
    }
}
