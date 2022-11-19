using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetTuningByName;

internal class GetTuningByNameQueryHandler : IRequestHandler<GetTuningByNameQuery, TuningDto>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetTuningByNameQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TuningDto> Handle(GetTuningByNameQuery request, CancellationToken cancellationToken)
    {
        var tuning = await _unitOfWork
            .GetRepository<ITuningRepository>()
            .FindGuitarTuningByName(request.TuningName);

        return _mapper.Map<TuningDto>(tuning);
    }
}
