using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Tunings.GetTuningByName
{
    internal class GetTuningByNameQueryHandler : IRequestHandler<GetTuningByNameQuery, GuitarTuningDto>
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

        public async Task<GuitarTuningDto> Handle(GetTuningByNameQuery request, CancellationToken cancellationToken)
        {
            var tuning = await _unitOfWork
                .GetRepository<IGuitarTuningRepository>()
                .FindGuitarTuningByName(request.TuningName);

            return _mapper.Map<GuitarTuningDto>(tuning);
        }
    }
}
