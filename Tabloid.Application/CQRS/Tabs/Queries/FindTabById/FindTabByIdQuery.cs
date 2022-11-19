using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.FindTabById
{
    public class FindTabByIdQuery : IRequest<TabDto>
    {
        public FindTabByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
