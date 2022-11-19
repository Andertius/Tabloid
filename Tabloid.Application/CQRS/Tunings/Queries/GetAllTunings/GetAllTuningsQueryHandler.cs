using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tunings.Queries.GetAllTunings
{
    internal class GetAllTuningsQueryHandler : IRequestHandler<GetAllTuningsQuery, TuningDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTuningsQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TuningDto[]> Handle(GetAllTuningsQuery request, CancellationToken cancellationToken)
        {
            var tunings = await _unitOfWork
                .GetRepository<ITuningRepository>()
                .GetAll();

            return tunings
                .Select(x => _mapper.Map<TuningDto>(x))
                .ToArray();
        }
    }
}
