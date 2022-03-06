﻿using FluentValidation;

using Tabloid.Application.Commands.Songs.UpdateSong;

namespace Tabloid.Application.Validators.Commands.Songs
{
    public class UpdateSongCommandValidator : AbstractValidator<UpdateSongCommand>
    {
        public UpdateSongCommandValidator()
        {
            RuleFor(x => x.Song)
                .NotEmpty();

            RuleFor(x => x.Song.Id)
                .NotEmpty();

            RuleFor(x => x.Song.SongName)
                .NotEmpty();
        }
    }
}
