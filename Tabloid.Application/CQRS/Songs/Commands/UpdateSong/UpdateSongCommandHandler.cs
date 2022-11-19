using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Tabloid.Application.Interfaces;
using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;

namespace Tabloid.Application.CQRS.Songs.Commands.UpdateSong
{
    internal class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, CommandResponse<SongDto>>
    {
        private readonly IUnitOfWork<Guid> _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSongCommandHandler(
            IUnitOfWork<Guid> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse<SongDto>> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<ISongRepository>();
            var entity = await repository.FindById(request.Song.Id);

            entity.SongName = request.Song.Name;
            entity.SongNumberInAlbum = request.Song.SongNumberInAlbum;
            entity.FullyMastered = request.Song.FullyMastered;
            entity.IsFavourite = request.Song.IsFavourite;

            entity.AlbumId = request.Song.Album.Id;
            entity.Album = await _unitOfWork
                .GetRepository<IAlbumRepository>()
                .FindById(request.Song.Album.Id);

            entity.Tabs = (await _unitOfWork
                .GetRepository<ITabRepository>()
                .GetAll())
                .Where(x => request.Song.Tabs.Any(y => y.Id == x.Id))
                .ToList();

            entity.Artists = (await _unitOfWork
                .GetRepository<IArtistRepository>()
                .GetAll())
                .Where(x => request.Song.Artists.Any(y => y.Id == x.Id))
                .ToList();

            entity.Genres = (await _unitOfWork
                .GetRepository<IGenreRepository>()
                .GetAll())
                .Where(x => request.Song.Genres.Any(y => y.Id == x.Id))
                .ToList();

            if (await repository.Contains(entity))
            {
                repository.Update(entity);
                await _unitOfWork.Save();

                return new CommandResponse<SongDto>(_mapper.Map<SongDto>(entity));
            }

            return new CommandResponse<SongDto>(
                _mapper.Map<SongDto>(entity),
                CommandResult.NotFound,
                "The song could not be found");
        }
    }
}
