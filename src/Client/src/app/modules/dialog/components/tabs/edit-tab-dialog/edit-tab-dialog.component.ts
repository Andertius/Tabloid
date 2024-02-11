import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { TuningDto } from 'src/app/models/dtos/tuning.dto';
import { StringService } from 'src/app/shared/services/string.service';
import { TuningService } from 'src/app/shared/services/tuning.service';

@Component({
  selector: 'app-edit-tab-dialog',
  templateUrl: './edit-tab-dialog.component.html',
  styleUrls: ['./edit-tab-dialog.component.scss']
})
export class EditTabDialogComponent implements OnInit {

  @Input() tab!: TabDto;
  tunings: TuningDto[] = [];

  formGroup = new FormGroup({
    name: new FormControl(''),
    link: new FormControl(''),
    difficulty: new FormControl(''),
    tuning: new FormControl(''),
  });

  constructor(
    private readonly stringService: StringService,
    private readonly tuningService: TuningService,
    public dialogRef: MatDialogRef<EditTabDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: TabDto) {
      this.tab = data;
        
      this.formGroup.controls["name"].setValue(this.tab.name);
      this.formGroup.controls["link"].setValue(this.tab.link);
      this.formGroup.controls["difficulty"].setValue(this.tab.difficulty);
      this.formGroup.controls["tuning"].setValue(this.tab.tuning);
    }

  ngOnInit() {
    this.tuningService.fetchJustTunings()
      .subscribe(response => {
        this.tunings = response.sort(this.stringService.compareNames);
      });
  }

  cancel() {
    this.dialogRef.close();
  }

  comparer(left: {id: string}, right: {id: string}): boolean {
    return left.id === right.id;
  }

}
