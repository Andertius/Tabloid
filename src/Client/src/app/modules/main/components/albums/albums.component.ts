import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { AddAlbumDialogComponent } from 'src/app/modules/dialog/components/albums/add-album-dialog/add-album-dialog.component';
import { AlbumService } from 'src/app/shared/services/album.service';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.scss']
})
export class AlbumsComponent implements OnInit {

  albums: AlbumDto[] = [];

  constructor(
    private readonly albumService: AlbumService,
    private readonly stringService: StringService,
    private readonly artistService: ArtistService,
    private readonly dialog: MatDialog,
    private readonly router: Router,
    private readonly snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.albumService.fetchAlbums()
      .subscribe(response => this.albums = response.sort(this.stringService.compareNamesRemoveArticles))
  }

  addAlbum() {
    const dialogRef = this.dialog.open(AddAlbumDialogComponent, {
      width: '350px',
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          this.artistService.fetchArtist(result.controls["artist"].value.id)
            .subscribe(response => {
              const album: AlbumDto = {
                id: "00000000-0000-0000-0000-000000000000",
                name: result.controls["name"].value,
                year: result.controls["year"].value,
                albumType: result.controls["albumType"].value,
                artist: response,
                cover: "",
                songs: [],
              };
    
              this.albumService.addAlbum(album)
                .subscribe(anotherResponse => {
                  this.router.navigate(['album', anotherResponse.object.id]);
                  this.snackBar.open('Album added', 'Close', { duration: 2500 });
                })
            })

          
        }
      })
  }

}
