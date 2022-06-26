import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Instrument } from 'src/app/models/enums/instrument.enum';

@Component({
  selector: 'app-add-tuning-dialog',
  templateUrl: './add-tuning-dialog.component.html',
  styleUrls: ['./add-tuning-dialog.component.scss']
})
export class AddTuningDialogComponent {

  public get instrument(): typeof Instrument {
    return Instrument; 
  }

  formGroup = new FormGroup({
    name: new FormControl(''),
    strings: new FormControl(''),
    stringNumber: new FormControl(''),
    instrument: new FormControl(''),
  });

  constructor(public dialogRef: MatDialogRef<AddTuningDialogComponent>) { }

  cancel() {
    this.dialogRef.close();
  }

}
