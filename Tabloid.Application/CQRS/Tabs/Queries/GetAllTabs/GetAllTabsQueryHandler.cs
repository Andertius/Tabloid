using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.GetAllTabs;

internal class GetAllTabsQueryHandler : IRequestHandler<GetAllTabsQuery, TabDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTabsQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TabDto[]> Handle(GetAllTabsQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork
            .GetRepository<ITabRepository>()
            .GetAll();

        return result
            .Select(x => _mapper.Map<TabDto>(x))
            .ToArray();
    }
}
