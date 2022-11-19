import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-add-artist-dialog',
  templateUrl: './add-artist-dialog.component.html',
  styleUrls: ['./add-artist-dialog.component.scss']
})
export class AddArtistDialogComponent {

  formGroup = new FormGroup({
    name: new FormControl(''),
  });

  constructor(public dialogRef: MatDialogRef<AddArtistDialogComponent>) { }

  cancel() {
    this.dialogRef.close();
  }

}
