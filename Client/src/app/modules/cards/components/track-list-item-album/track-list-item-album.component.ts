import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { DeleteDialogComponent } from 'src/app/modules/dialog/components/delete-dialog/delete-dialog.component';
import { EditSongDialogComponent } from 'src/app/modules/dialog/components/songs/edit-song-dialog/edit-song-dialog.component';
import { SongService } from 'src/app/shared/services/song.service'

@Component({
  selector: 'app-track-list-item-album',
  templateUrl: './track-list-item-album.component.html',
  styleUrls: ['./track-list-item-album.component.scss']
})
export class TrackListItemAlbumComponent implements OnInit {

  @Input() song!: SongDto;
  @Input() album!: AlbumDto;
  @Input() featuredArtists!: ArtistDto[];

  @Output() whenFavourite = new EventEmitter();
  @Output() whenMastered = new EventEmitter();

  constructor(
    private readonly songService: SongService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.featuredArtists = this.song.artists.filter(x => x.id !== this.album.artist.id);
    console.log(this.song);
  }

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
