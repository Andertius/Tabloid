import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';

@Component({
  selector: 'app-edit-artist-dialog',
  templateUrl: './edit-artist-dialog.component.html',
  styleUrls: ['./edit-artist-dialog.component.scss']
})
export class EditArtistDialogComponent {
  
  artist: ArtistDto;

  formGroup = new FormGroup({
    name: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<EditArtistDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ArtistDto) {
      this.artist = data;
      this.formGroup.controls["name"].setValue(this.artist.name);
    }

  cancel() {
    this.dialogRef.close();
  }
}
