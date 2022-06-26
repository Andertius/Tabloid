using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Commands.SetFavourite
{
    public class SetFavouriteCommand : IRequest<CommandResponse<SongDto>>
    {
        public SetFavouriteCommand(Guid songId, bool isFavourite)
        {
            SongId = songId;
            IsFavourite = isFavourite;
        }

        public Guid SongId { get; set; }

        public bool IsFavourite { get; set; }
    }
}
