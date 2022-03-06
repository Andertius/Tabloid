using AutoMapper;

using MediatR;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Interfaces;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Application.Queries.Tunings.GetTuningByStringNumber
{
    public class GetTuningByStringNumberQueryHandler : IRequestHandler<GetTuningByStringNumberQuery, GuitarTuningDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetTuningByStringNumberQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuitarTuningDto[]> Handle(GetTuningByStringNumberQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<IGuitarTuningRepository>()
                .GetAllGuitarTuningsByStringNumber(request.StringNumber);

            return result.Select(tuning => _mapper.Map<GuitarTuningDto>(tuning)).ToArray();
        }
    }
}
