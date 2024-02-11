import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TuningDto } from 'src/app/models/dtos/tuning.dto';
import { Instrument } from 'src/app/models/enums/instrument.enum';

@Component({
  selector: 'app-edit-tuning-dialog',
  templateUrl: './edit-tuning-dialog.component.html',
  styleUrls: ['./edit-tuning-dialog.component.scss']
})
export class EditTuningDialogComponent {

  tuning: TuningDto;

  public get instrument(): typeof Instrument {
    return Instrument; 
  }

  formGroup = new FormGroup({
    name: new FormControl(''),
    strings: new FormControl(''),
    stringNumber: new FormControl(''),
    instrument: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<EditTuningDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TuningDto) {
      this.tuning = data;
      this.formGroup.controls["name"].setValue(this.tuning.name);
      this.formGroup.controls["strings"].setValue(this.tuning.strings);
      this.formGroup.controls["stringNumber"].setValue(this.tuning.stringNumber);
      this.formGroup.controls["instrument"].setValue(this.tuning.instrument);
    }

  cancel() {
    this.dialogRef.close();
  }

}
