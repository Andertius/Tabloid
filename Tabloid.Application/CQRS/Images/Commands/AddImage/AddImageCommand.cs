using MediatR;

namespace Tabloid.Application.CQRS.Images.Commands.AddImage
{
    public class AddImageCommand : IRequest<CommandResponse<string>>
    {
        public AddImageCommand(Guid entityId, string fileName, Type entityType)
        {
            EntityId = entityId;
            FileName = fileName;
            EntityType = entityType;
        }

        public Type EntityType { get; set; }

        public Guid EntityId { get; set; }

        public string FileName { get; set; }
    }
}
