import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { GenreDto } from 'src/app/models/dtos/genre.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { GenreService } from 'src/app/shared/services/genre.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-edit-song-dialog',
  templateUrl: './edit-song-dialog.component.html',
  styleUrls: ['./edit-song-dialog.component.scss']
})
export class EditSongDialogComponent implements OnInit {

  song: SongDto;
  genres: GenreDto[] = [];
  artists: ArtistDto[] = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    songNumber: new FormControl(''),
    artists: new FormControl(''),
    genres: new FormControl(''),
  });

  constructor(
    private readonly genreService: GenreService,
    private readonly artistService: ArtistService,
    private readonly stringService: StringService,
    public dialogRef: MatDialogRef<EditSongDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SongDto) {
      this.song = data;
      this.formGroup.controls["name"].setValue(this.song.name);
      this.formGroup.controls["songNumber"].setValue(this.song.songNumberInAlbum);
      this.formGroup.controls["artists"].setValue(this.song.artists);
      this.formGroup.controls["genres"].setValue(this.song.genres);
    }

  ngOnInit() {
    this.genreService.fetchJustNames()
      .subscribe(response => {
        this.genres = response.sort(this.stringService.compareNamesRemoveArticles);
      });

    this.artistService.fetchJustNames()
      .subscribe(response => {
        this.artists = response.sort(this.stringService.compareNamesRemoveArticles);
      });
  }

  cancel() {
    this.dialogRef.close();
  }

  comparer(left: {id: string}, right: {id: string}): boolean {
    return left.id === right.id;
  }

}
