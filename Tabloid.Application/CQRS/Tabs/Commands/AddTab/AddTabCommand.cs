using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Commands.AddTab
{
    public class AddTabCommand : IRequest<CommandResponse<TabDto>>
    {
        public AddTabCommand(TabDto tab)
        {
            Tab = tab;
        }

        public TabDto Tab { get; set; }
    }
}
