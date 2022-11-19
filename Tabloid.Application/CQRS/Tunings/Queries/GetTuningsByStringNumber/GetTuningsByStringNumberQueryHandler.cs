using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetTuningsByStringNumber;

internal class GetTuningsByStringNumberQueryHandler : IRequestHandler<GetTuningsByStringNumberQuery, TuningDto[]>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public GetTuningsByStringNumberQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TuningDto[]> Handle(GetTuningsByStringNumberQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork
            .GetRepository<ITuningRepository>()
            .GetAllGuitarTuningsByStringNumber(request.StringNumber);

        return result.Select(tuning => _mapper.Map<TuningDto>(tuning)).ToArray();
    }
}
