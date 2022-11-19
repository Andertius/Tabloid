using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.GetAllTabsBySong
{
    internal class GetAllTabsBySongQueryHandler : IRequestHandler<GetAllTabsBySongQuery, TabDto[]>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTabsBySongQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TabDto[]> Handle(GetAllTabsBySongQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<ITabRepository>()
                .GetAllTabsBySong(request.SongId);

            return result
                .Select(x => _mapper.Map<TabDto>(x))
                .ToArray();
        }
    }
}
