using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Application.CQRS.Images.Commands.AddImage;

internal class AddImageCommandHandler : IRequestHandler<AddImageCommand, CommandResponse<string>>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;

    public AddImageCommandHandler(IUnitOfWork<Guid> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommandResponse<string>> Handle(AddImageCommand request, CancellationToken cancellationToken)
    {
        if (request.EntityType == typeof(Artist))
        {
            var artist = await _unitOfWork
               .GetRepository<IArtistRepository>()
               .FindById(request.EntityId);

            if (artist is null)
            {
                return new CommandResponse<string>(
                    request.FileName,
                    Domain.Enums.CommandResult.NotFound,
                    "Artist could not be found.");
            }

            artist.Image = request.FileName;
        }
        else if (request.EntityType == typeof(Album))
        {
            var album = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindById(request.EntityId);

            if (album is null)
            {
                return new CommandResponse<string>(
                    request.FileName,
                    Domain.Enums.CommandResult.NotFound,
                    "Album could not be found.");
            }

            album.Cover = request.FileName;
        }
        else
        {
            return new CommandResponse<string>(
                request.FileName,
                Domain.Enums.CommandResult.Failure,
                "The entity has to be either an artist or an album.");
        }

        await _unitOfWork.Save();
        return new CommandResponse<string>(request.FileName);
    }
}
