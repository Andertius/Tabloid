using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Songs.Commands.AddSong
{
    internal class AddSongCommandHandler : IRequestHandler<AddSongCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public AddSongCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ISongRepository>();
            var entity = _mapper.Map<Song>(request.Song);
            entity.Artists = null;
            entity.Genres = null;
            entity.Tabs = null;

            if (!await repository.HasKey(request.Song.Id))
            {
                await repository.Insert(entity);
                await _unitOfWork.Save();

                var artists = (await _unitOfWork
                    .GetRepository<IArtistRepository>()
                    .GetAll())
                    .Where(x => request.Song.Artists.Any(y => x.Id == y.Id))
                    .ToList();

                var genres = (await _unitOfWork
                    .GetRepository<IGenreRepository>()
                    .GetAll())
                    .Where(x => request.Song.Genres.Any(y => x.Id == y.Id))
                    .ToList();

                entity.Artists = artists;
                entity.Genres = genres;
                await _unitOfWork.Save();

                entity.Genres = entity.Genres
                    .Select(x => new Genre() { Id = x.Id, Name = x.Name, Songs = null })
                    .ToList();

                entity.Album = null;
                entity.Artists = entity.Artists
                    .Select(x => new Artist
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Image = x.Image,
                    })
                    .ToList();

                return new CommandResponse<SongDto>(_mapper.Map<SongDto>(entity));
            }

            return new CommandResponse<SongDto>(
                result: CommandResult.Failure,
                errorMessage: "The song already exists");
        }
    }
}
