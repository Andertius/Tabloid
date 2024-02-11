using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Images.Commands.DeleteImage;

internal class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, CommandResponse<string>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;

    public DeleteImageCommandHandler(IUnitOfWork<Guid> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommandResponse<string>> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        string? fileName;

        if (request.EntityType == typeof(Artist))
        {
            var artist = await _unitOfWork
               .GetRepository<IArtistRepository>()
               .FindById(request.EntityId);

            if (artist is null)
            {
                return new CommandResponse<string>(
                    null,
                    CommandResult.NotFound,
                    "Artist could not be found.");
            }

            fileName = artist.Image;
            artist.Image = null;
        }
        else if (request.EntityType == typeof(Album))
        {
            var album = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindById(request.EntityId);

            if (album is null)
            {
                return new CommandResponse<string>(
                    null,
                    CommandResult.NotFound,
                    "Album could not be found.");
            }

            fileName = album.Cover;
            album.Cover = null;
        }
        else
        {
            return new CommandResponse<string>(
                null,
                CommandResult.Failure,
                "The entity has to be either an artist or an album.");
        }

        await _unitOfWork.Save();
        return new CommandResponse<string>(fileName);
    }
}
