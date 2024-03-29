﻿using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<CommandResponse<AlbumDto>>
    {
        public UpdateAlbumCommand(AlbumDto album)
        {
            Album = album;
        }

        public AlbumDto Album { get; set; }
    }
}
