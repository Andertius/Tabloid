import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { AddAlbumDialogComponent } from 'src/app/modules/dialog/components/albums/add-album-dialog/add-album-dialog.component';
import { EditArtistDialogComponent } from 'src/app/modules/dialog/components/artists/edit-artist-dialog/edit-artist-dialog.component';
import { AlbumService } from 'src/app/shared/services/album.service';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { ImageService } from 'src/app/shared/services/image.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {
  
  @Output() rerenderAfterEdit = new EventEmitter<ArtistDto>();

  artist!: ArtistDto;
  favourites: SongDto[] = [];
  mastered: SongDto[] = [];

  constructor(
    private readonly artistService: ArtistService,
    private readonly albumService: AlbumService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly stringService: StringService,
    private readonly imageService: ImageService,
    private readonly snackBar: MatSnackBar,
    private readonly dialog: MatDialog) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get("id");

    if (id === null) {
      this.router.navigate(['home']);
      return;
    }

    this.artistService.fetchArtist(id!)
      .subscribe(response => {
        this.artist = response;

        this.artist.songs.sort(this.stringService.compareNamesRemoveArticles);
        this.artist.albums.sort((x, y) => y.year - x.year);

        this.favourites = this.artist.songs.filter(x => x.isFavourite);
        this.mastered = this.artist.songs.filter(x => x.fullyMastered);
      });
  }

  whenFavourite(event: any) {
    const index = this.artist.songs.map(x => x.id).indexOf(event.value.id)
    this.artist.songs[index] = event.value
    this.favourites = this.artist.songs.filter(x => x.isFavourite);
  }

  whenMastered(event: any) {
    const index = this.artist.songs.map(x => x.id).indexOf(event.value.id)
    this.artist.songs[index] = event.value
    this.mastered = this.artist.songs.filter(x => x.fullyMastered);
  }

  getImageSource() {
    return this.imageService.getArtistImageSource(this.artist);
  }

  uploadAvatar(files: FileList | null) {
    if (files === null || files.length === 0) {
      return;
    }

    const avatar = files[0];

    if (avatar !== null) {
      const formData = new FormData();
      formData.append('file', avatar!);

      this.artistService.uploadAvatar(this.artist.id, formData)
        .subscribe((response: { fileName: string }) => {
          this.artist.image = response.fileName;
          this.snackBar.open('Avatar uploaded', 'Close', { duration: 2500 });
        });
    }
  }

  editArtist() {
    const dialogRef = this.dialog.open(EditArtistDialogComponent, {
      width: '300px',
      data: this.artist,
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          this.handleEdit(result.controls["name"].value);
        }
      })
  }

  handleEdit(name: string) {
    const copy: ArtistDto = JSON.parse(JSON.stringify(this.artist));
    this.artist.name = name;
    this.artistService.editArtist(this.artist)
      .subscribe(response => {
        this.artist = response.object;
        //this.rerenderAfterEdit.emit(this.artist);
        const snackBarRef = this.snackBar.open('Artist updated', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.artistService.editArtist(copy)
            .subscribe(anotherResponse => {
              this.artist = anotherResponse.object;
              //this.rerenderAfterEdit.emit(this.artist);
            })
        });
      });
  }

  addAlbum() {
    const dialogRef = this.dialog.open(AddAlbumDialogComponent, {
      width: '350px',
      data: this.artist.id
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
            const album: AlbumDto = {
              id: "00000000-0000-0000-0000-000000000000",
              name: result.controls["name"].value,
              year: result.controls["year"].value,
              albumType: result.controls["albumType"].value,
              artist: this.artist,
              cover: "",
              songs: [],
            };
  
            this.albumService.addAlbum(album)
              .subscribe(response => {
                this.snackBar.open('Album added', 'Close', { duration: 2500 });
                this.artist.albums.push(response.object);
              });        
        }
      })
  }

}
