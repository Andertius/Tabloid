import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GenreDto } from 'src/app/models/dtos/genre.dto';

@Component({
  selector: 'app-edit-genre-dialog',
  templateUrl: './edit-genre-dialog.component.html',
  styleUrls: ['./edit-genre-dialog.component.scss']
})
export class EditGenreDialogComponent {

  genre: GenreDto;

  formGroup = new FormGroup({
    name: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<EditGenreDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: GenreDto) {
      this.genre = data;
      this.formGroup.controls["name"].setValue(this.genre.name);
    }

  cancel() {
    this.dialogRef.close();
  }
}
