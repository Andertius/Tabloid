import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { GenreDto } from 'src/app/models/dtos/genre.dto';
import { AlbumService } from 'src/app/shared/services/album.service';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { GenreService } from 'src/app/shared/services/genre.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-add-song-dialog',
  templateUrl: './add-song-dialog.component.html',
  styleUrls: ['./add-song-dialog.component.scss']
})
export class AddSongDialogComponent implements OnInit {
  
  genres: GenreDto[] = [];
  artists: ArtistDto[] = [];
  albums: AlbumDto[] = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    songNumber: new FormControl(''),
    artists: new FormControl(''),
    albums: new FormControl(''),
    genres: new FormControl(''),
  });

  constructor(
    private readonly genreService: GenreService,
    private readonly artistService: ArtistService,
    private readonly albumService: AlbumService,
    private readonly stringService: StringService,
    public dialogRef: MatDialogRef<AddSongDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { artistId: string, albumId: string }) { }

  ngOnInit() {
    if (this.data !== null) {      
      this.formGroup.controls["albums"].disable();
    }

    this.genreService.fetchJustNames()
      .subscribe(response => {
        this.genres = response.sort(this.stringService.compareNamesRemoveArticles);
      });

    this.artistService.fetchJustNames()
      .subscribe(response => {
        this.artists = response.sort(this.stringService.compareNamesRemoveArticles);

        if (this.data !== null) {
          this.formGroup.controls["artists"].setValue(this.artists.filter(x => x.id === this.data.artistId));
        }
      });

      this.albumService.fetchJustNames()
        .subscribe(response => {
          this.albums = response.sort(this.stringService.compareNamesRemoveArticles);

          if (this.data !== null) {
            this.formGroup.controls["albums"].setValue(this.albums.filter(x => x.id === this.data.albumId)[0]);
          }
        });    
  }

  cancel() {
    this.dialogRef.close();
  }

}
