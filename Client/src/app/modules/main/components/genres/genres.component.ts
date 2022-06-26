import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { GenreDto } from 'src/app/models/dtos/genre.dto';
import { AddGenreDialogComponent } from 'src/app/modules/dialog/components/genres/add-genre-dialog/add-genre-dialog.component';
import { GenreService } from 'src/app/shared/services/genre.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.scss']
})
export class GenresComponent implements OnInit {

  checkboxChecked: boolean = false;
  allGenres: GenreDto[] = [];
  genresWithTracks: GenreDto[] = [];
  genres: GenreDto[] = [];
  formControl: FormControl;

  constructor(
    private readonly dialog: MatDialog,
    private readonly genreService: GenreService,
    private readonly stringService: StringService) {
      this.formControl = new FormControl('');
    }

  ngOnInit(): void {
    this.genreService.fetchGenres()
      .subscribe(response => {
        this.allGenres = response.sort(this.stringService.compareNames);
        this.genresWithTracks = this.allGenres.filter(x => x.songs.length > 0);

        this.genres = JSON.parse(JSON.stringify(this.genresWithTracks));
      })

    this.formControl.valueChanges.subscribe(value => {
      this.genres = this.checkboxChecked
        ? this.allGenres.filter(x => x.name.toLocaleLowerCase().includes(value.toLocaleLowerCase()))
        : this.genresWithTracks.filter(x => x.name.toLocaleLowerCase().includes(value.toLocaleLowerCase()));
    });
  }

  addGenre() {
    const dialogRef = this.dialog.open(AddGenreDialogComponent, {
      width: '250px',
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          this.genreService.addGenre({name: result.controls["name"].value, songs: [], id: '00000000-0000-0000-0000-000000000000'})
            .subscribe(response => {
              this.genres.push(response.object);
              this.genres.sort(this.stringService.compareNames);
              
              this.allGenres.push(JSON.parse(JSON.stringify(response.object)));
              this.allGenres.sort(this.stringService.compareNames);
            })
        }
      })
  }

  onCheckboxChange(event: any) {
    if (!event.checked) {
      this.genres = this.genres.filter(x => x.songs.length > 0)
    } else {
      this.genres = JSON.parse(JSON.stringify(this.allGenres))
    }

    this.checkboxChecked = event.checked;
  }

  rerenderGenres(event: any) {
    const allGenresIndex = this.allGenres.indexOf(this.allGenres.filter(x => x.id === event.genre.id)[0]);
    const allGenresWithTabs = this.genresWithTracks.indexOf(this.genresWithTracks.filter(x => x.id === event.genre.id)[0]);
    const allGenres = this.genres.indexOf(this.genres.filter(x => x.id === event.genre.id)[0]);

    this.allGenres[allGenresIndex] = event.genre;
    this.genresWithTracks[allGenresWithTabs] = event.genre;
    this.genres[allGenres] = event.genre;

    this.allGenres = this.allGenres.sort(this.stringService.compareNames);
    this.genresWithTracks = this.genresWithTracks.sort(this.stringService.compareNames);
    this.genres = this.genres.sort(this.stringService.compareNames);

    this.allGenres = this.allGenres.filter(x => x.id !== event.id).sort(this.stringService.compareNames);
    this.genresWithTracks = this.genresWithTracks.filter(x => x.id !== event.id).sort(this.stringService.compareNames);
    this.genres = this.genres.filter(x => x.id !== event.id).sort(this.stringService.compareNames);
  }

}
