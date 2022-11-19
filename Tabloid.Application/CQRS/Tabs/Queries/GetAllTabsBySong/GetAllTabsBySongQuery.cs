using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.GetAllTabsBySong
{
    public class GetAllTabsBySongQuery : IRequest<TabDto[]>
    {
        public GetAllTabsBySongQuery(Guid songId)
        {
            SongId = songId;
        }

        public Guid SongId { get; set; }
    }
}
