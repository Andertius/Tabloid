import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { EditAlbumDialogComponent } from 'src/app/modules/dialog/components/albums/edit-album-dialog/edit-album-dialog.component';
import { AddSongDialogComponent } from 'src/app/modules/dialog/components/songs/add-song-dialog/add-song-dialog.component';
import { AlbumService } from 'src/app/shared/services/album.service';
import { ImageService } from 'src/app/shared/services/image.service';
import { SongService } from 'src/app/shared/services/song.service';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {

  album!: AlbumDto;

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    private readonly albumService: AlbumService,
    private readonly songService: SongService,
    private readonly imageService: ImageService,
    private readonly dialog: MatDialog,
    private readonly snackBar: MatSnackBar) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id === null) {
      this.router.navigate(['home']);
      return;
    }
    
    this.albumService.fetchAlbum(id!).subscribe(response => {
      this.album = response;
      this.album.songs.sort((x, y) => x.songNumberInAlbum - y.songNumberInAlbum);
    });
  }

  getImageSource() {
    return this.imageService.getAlbumImageSource(this.album);
  }

  uploadAvatar(files: FileList | null) {
    if (files === null || files.length === 0) {
      return;
    }

    const avatar = files[0];

    if (avatar !== null) {
      const formData = new FormData();
      formData.append('file', avatar!);

      this.albumService.uploadCover(this.album.id, formData)
        .subscribe((response: { fileName: string }) => {
          this.album.cover = response.fileName;
          this.snackBar.open('Cover uploaded', 'Close', { duration: 2500 });
        });
    }
  }

  addSong() {
    const dialogRef = this.dialog.open(AddSongDialogComponent, {
      width: '350px',
      data: { artistId: this.album.artist.id, albumId: this.album.id }
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          const song: SongDto = {
            id: "00000000-0000-0000-0000-000000000000",
            name: result.controls["name"].value,
            songNumberInAlbum: result.controls["songNumber"].value,
            fullyMastered: false,
            isFavourite: false,
            genres: result.controls["genres"].value,
            artists: result.controls["artists"].value,
            album: {
              id: this.album.id,
              name: "",
              cover: "",
              albumType: 0,
              artist: null!,
              year: 0,
              songs: [],
            },
            tabs: [],
          };

          this.songService.addSong(song)
            .subscribe(response => {
              this.snackBar.open('Song added', 'Close', { duration: 2500 });
              this.album.songs.push(response.object);
              this.album.songs.sort((x, y) => x.songNumberInAlbum - y.songNumberInAlbum);
            });      
        }
      })
  }

  editAlbum() {
    const dialogRef = this.dialog.open(EditAlbumDialogComponent, {
      width: '350px',
      data: this.album,
    });

    dialogRef
      .afterClosed()
      .subscribe(result => {
        this.handleEdit(result);
      });
  }

  handleEdit(result: FormGroup) {
    const copy: AlbumDto = JSON.parse(JSON.stringify(this.album));
    const album: AlbumDto = {
      id: this.album.id,
      name: this.album.name,
      year: this.album.year,
      cover: this.album.cover,
      albumType: this.album.albumType,
      artist: this.album.artist,
      songs: this.album.songs
    };

    this.albumService.editAlbum(album)
      .subscribe(response => {
        this.album = response.object;

        const snackBarRef = this.snackBar.open('Album updated', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.albumService.editAlbum(copy)
            .subscribe(anotherResponse => {
              this.album = anotherResponse.object;
            })
        });
      });
  }
}
