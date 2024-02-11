using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.FindTuningById;

public class FindTuningByIdQueryHandler : IRequestHandler<FindTuningByIdQuery, TuningDto?>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMapper _mapper;

    public FindTuningByIdQueryHandler(
        IUnitOfWork<Guid> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TuningDto?> Handle(FindTuningByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork
            .GetRepository<ITuningRepository>()
            .FindById(request.Id);

        return _mapper.Map<TuningDto?>(entity);
    }
}
