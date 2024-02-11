import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { AlbumType } from 'src/app/models/enums/album-type.enum';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-add-album-dialog',
  templateUrl: './add-album-dialog.component.html',
  styleUrls: ['./add-album-dialog.component.scss']
})
export class AddAlbumDialogComponent implements OnInit {
  artists: ArtistDto[] = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    artist: new FormControl(''),
    albumType: new FormControl(''),
    year: new FormControl(''),
  });

  public get albumType(): typeof AlbumType {
    return AlbumType;
  }

  constructor(
    private readonly stringService: StringService,
    private readonly artistService: ArtistService,
    public dialogRef: MatDialogRef<AddAlbumDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public artistId: string) { }

  ngOnInit(): void {
    if (!this.stringService.isNullOrEmpty(this.artistId)) {
      this.formGroup.controls["artist"].disable();
    }

    this.artistService.fetchJustNames()
      .subscribe(response =>{
        this.artists = response.sort(this.stringService.compareNamesRemoveArticles);

        if (!this.stringService.isNullOrEmpty(this.artistId)) {
          this.formGroup.controls["artist"].setValue(this.artists.filter(x => x.id === this.artistId)[0]);
        }
      })
  }

  cancel() {
    this.dialogRef.close();
  }

  comparer(left: {id: string}, right: {id: string}): boolean {
    return left.id === right.id;
  }

}
