import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { TuningDto } from 'src/app/models/dtos/tuning.dto';
import { StringService } from 'src/app/shared/services/string.service';
import { TuningService } from 'src/app/shared/services/tuning.service';

@Component({
  selector: 'app-add-tab-dialog',
  templateUrl: './add-tab-dialog.component.html',
  styleUrls: ['./add-tab-dialog.component.scss']
})
export class AddTabDialogComponent implements OnInit {
  
  tunings: TuningDto[] = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    link: new FormControl(''),
    stringNumber: new FormControl(''),
    difficulty: new FormControl(''),
    tuning: new FormControl(''),
  });

  constructor(
    private readonly stringService: StringService,
    private readonly tuningService: TuningService,
    public dialogRef: MatDialogRef<AddTabDialogComponent>) { }

  ngOnInit(): void {
    this.tuningService.fetchTunings()
      .subscribe(response => this.tunings = response.sort(this.stringService.compareNames))
  }

  cancel() {
    this.dialogRef.close();
  }

}
