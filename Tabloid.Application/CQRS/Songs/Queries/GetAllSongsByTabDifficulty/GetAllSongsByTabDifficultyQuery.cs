using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTabDifficulty;

public class GetAllSongsByTabDifficultyQuery : IRequest<SongDto[]>
{
    public GetAllSongsByTabDifficultyQuery(double? difficulty)
    {
        Difficulty = difficulty;
    }

    public double? Difficulty { get; set; }
}
