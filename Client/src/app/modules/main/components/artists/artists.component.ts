import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { AddArtistDialogComponent } from 'src/app/modules/dialog/components/artists/add-artist-dialog/add-artist-dialog.component';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.scss']
})
export class ArtistsComponent implements OnInit {

  artists: ArtistDto[] = [];

  constructor(
    private readonly artistService: ArtistService,
    private readonly stringService: StringService,
    private readonly dialog: MatDialog,
    private readonly router: Router,
    private readonly snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.artistService.fetchArtists()
      .subscribe(response => this.artists = response.sort(this.stringService.compareNamesRemoveArticles))
  }

  addArtist() {
    const dialogRef = this.dialog.open(AddArtistDialogComponent, {
      width: '300px',
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          const artist: ArtistDto = {
            id: "00000000-0000-0000-0000-000000000000",
            name: result.controls["name"].value,
            image: "",
            songs: [],
            albums: [],
          };

          this.artistService.addArtist(artist)
            .subscribe(response => {
              this.router.navigate(['artist', response.object.id]);
              this.snackBar.open('Artist added', 'Close', { duration: 2500 });
            })
        }
      })
  }

}
