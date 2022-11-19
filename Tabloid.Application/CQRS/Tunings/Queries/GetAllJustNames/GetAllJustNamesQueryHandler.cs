using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetAllJustNames;

internal class GetAllJustNamesQueryHandler : IRequestHandler<GetAllJustNamesQuery, JustNameDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllJustNamesQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<JustNameDto[]> Handle(GetAllJustNamesQuery request, CancellationToken cancellationToken)
    {
        var artists = await _unitOfWork
            .GetRepository<ITuningRepository>()
            .GetAll();

        return artists
            .Select(x => _mapper.Map<JustNameDto>(x))
            .ToArray();
    }
}
