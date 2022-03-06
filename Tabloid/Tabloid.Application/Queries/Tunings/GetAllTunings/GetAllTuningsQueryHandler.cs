using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Tunings.GetAllTunings
{
    internal class GetAllTuningsQueryHandler : IRequestHandler<GetAllTuningsQuery, GuitarTuningDto[]>
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

        public async Task<GuitarTuningDto[]> Handle(GetAllTuningsQuery request, CancellationToken cancellationToken)
        {
            var tunings = await _unitOfWork
                .GetRepository<IGuitarTuningRepository>()
                .GetAll();

            return tunings
                .Select(x => _mapper.Map<GuitarTuningDto>(x))
                .ToArray();
        }
    }
}
