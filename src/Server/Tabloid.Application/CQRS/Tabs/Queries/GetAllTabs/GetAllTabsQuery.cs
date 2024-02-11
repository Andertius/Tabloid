using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Queries.GetAllTabs;

public class GetAllTabsQuery : IRequest<TabDto[]>
{
}
