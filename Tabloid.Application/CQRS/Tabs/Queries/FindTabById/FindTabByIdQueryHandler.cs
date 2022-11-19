using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.FindTabById
{
    internal class FindTabByIdQueryHandler : IRequestHandler<FindTabByIdQuery, TabDto>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public FindTabByIdQueryHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TabDto> Handle(FindTabByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork
                .GetRepository<ITabRepository>()
                .FindById(request.Id);

            return _mapper.Map<TabDto>(result);
        }
    }
}
