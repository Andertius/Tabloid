import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { AlbumType } from 'src/app/models/enums/album-type.enum';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-edit-album-dialog',
  templateUrl: './edit-album-dialog.component.html',
  styleUrls: ['./edit-album-dialog.component.scss']
})
export class EditAlbumDialogComponent implements OnInit {

  public get albumType(): typeof AlbumType {
    return AlbumType;
  }

  album: AlbumDto;
  artists: ArtistDto[]=  [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    artist: new FormControl(''),
    albumType: new FormControl(''),
    year: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<EditAlbumDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AlbumDto,
    private readonly artistService: ArtistService,
    private readonly stringService: StringService) {
      this.album = data;
      this.formGroup.controls["name"].setValue(this.album.name);
      this.formGroup.controls["artist"].setValue(this.album.artist);
      this.formGroup.controls["albumType"].setValue(this.album.albumType);
      this.formGroup.controls["year"].setValue(this.album.year);
  }

  ngOnInit(): void {
    this.artistService.fetchJustNames()
      .subscribe(response =>{
        this.artists = response.sort(this.stringService.compareNamesRemoveArticles);
      })
  }

  cancel() {
    this.dialogRef.close();
  }

  comparer(left: {id: string}, right: {id: string}): boolean {
    return left.id === right.id;
  }

}
