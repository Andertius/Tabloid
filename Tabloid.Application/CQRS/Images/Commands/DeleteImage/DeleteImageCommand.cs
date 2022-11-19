using System;

using MediatR;

namespace Tabloid.Application.CQRS.Images.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest<CommandResponse<string>>
    {
        public DeleteImageCommand(Guid entityId, Type entityType)
        {
            EntityId = entityId;
            EntityType = entityType;
        }

        public Guid EntityId { get; set; }

        public Type EntityType { get; set; }
    }
}
