using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Tabs.Commands.DeleteTab
{
    public class DeleteTabCommand : IRequest<CommandResponse<TabDto>>
    {
        public DeleteTabCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
