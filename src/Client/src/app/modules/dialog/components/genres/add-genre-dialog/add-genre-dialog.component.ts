import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-genre-dialog',
  templateUrl: './add-genre-dialog.component.html',
  styleUrls: ['./add-genre-dialog.component.scss']
})
export class AddGenreDialogComponent {
  
  formGroup = new FormGroup({
    name: new FormControl(''),
  });

  constructor(public dialogRef: MatDialogRef<AddGenreDialogComponent>) { }

  cancel() {
    this.dialogRef.close();
  }
}
