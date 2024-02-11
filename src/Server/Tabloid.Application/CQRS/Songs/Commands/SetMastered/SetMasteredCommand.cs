using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.SetMastered;

public class SetMasteredCommand : IRequest<CommandResponse<SongDto>>
{
    public SetMasteredCommand(Guid songId, bool isMastered)
    {
        SongId = songId;
        IsMastered = isMastered;
    }

    public Guid SongId { get; set; }

    public bool IsMastered { get; set; }
}
