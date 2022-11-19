using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Commands.DeleteTab;

internal class DeleteTabCommandHandler : IRequestHandler<DeleteTabCommand, CommandResponse<TabDto>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTabCommandHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<TabDto>> Handle(DeleteTabCommand request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.GetRepository<ITabRepository>();
        var entity = await repository.FindById(request.Id);
        repository.Remove(entity);

        await _unitOfWork.Save();

        return new CommandResponse<TabDto>(_mapper.Map<TabDto>(entity));
    }
}
