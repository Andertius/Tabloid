using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Commands.UpdateTab
{
    public class UpdateTabCommand : IRequest<CommandResponse<TabDto>>
    {
        public UpdateTabCommand(TabDto tab)
        {
            Tab = tab;
        }

        public TabDto Tab { get; set; }
    }
}
