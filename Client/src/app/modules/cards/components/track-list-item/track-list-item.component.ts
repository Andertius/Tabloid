import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { DeleteDialogComponent } from 'src/app/modules/dialog/components/delete-dialog/delete-dialog.component';
import { EditSongDialogComponent } from 'src/app/modules/dialog/components/songs/edit-song-dialog/edit-song-dialog.component';
import { ImageService } from 'src/app/shared/services/image.service';
import { SongService } from 'src/app/shared/services/song.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-track-list-item',
  templateUrl: './track-list-item.component.html',
  styleUrls: ['./track-list-item.component.scss']
})
export class TrackListItemComponent {

  @Input() song!: SongDto;
  @Input() album!: AlbumDto;
  
  @Output() whenFavourite = new EventEmitter();
  @Output() whenMastered = new EventEmitter();

  constructor(
    private readonly songService: SongService,
    private readonly stringService: StringService,
    private readonly imageService: ImageService,
    public dialog: MatDialog) { }

  setFavourite() {
    this.songService.setFavourite(this.song.id, !this.song.isFavourite)
      .subscribe(response => {
        this.song = response.object;
        
        if (this.whenFavourite !== undefined) {
          this.whenFavourite.emit({value: this.song });
        }
      });
  }

  setMastered() {
    this.songService.setMastered(this.song.id, !this.song.fullyMastered)
      .subscribe(response => {
        this.song = response.object;

        if (this.whenFavourite !== undefined) {
          this.whenMastered.emit({value: this.song });
        }
      });
  }

  deleteSong() {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: { name: this.song.name },
    });

    dialogRef
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.handleDelete()
        }
      })
  }

  editSong() {
    const dialogRef = this.dialog.open(EditSongDialogComponent, {
      width: '400px',
      data: this.song,
    });

    dialogRef
      .afterClosed()
      .subscribe(result => {
        if (result !== undefined) {
          this.handleEdit(result);
        }
      })
  }

  getImageSource() {
    return this.imageService.getAlbumImageSource(this.album);
  }

  handleDelete() {
    this.songService.deleteSong(this.song.id)
      .subscribe(response => this.album.songs = this.album.songs.filter(x => x.id !== response.object.id));
  }

  handleEdit(result: SongDto) {
    const songs = this.album.songs;
    result.album = this.album;
    result.album.songs = [];

    this.songService.editSong(result)
      .subscribe(response => {
        const index = this.album.songs.indexOf(this.song);
        this.song = response.object;
        this.album.songs = songs;
        this.album.songs[index] = this.song;
      });
  }
}
