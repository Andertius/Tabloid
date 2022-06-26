import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { TuningDto } from 'src/app/models/dtos/tuning.dto';
import { DeleteDialogComponent } from 'src/app/modules/dialog/components/delete-dialog/delete-dialog.component';
import { EditTuningDialogComponent } from 'src/app/modules/dialog/components/tunings/edit-tuning-dialog/edit-tuning-dialog.component';
import { TuningService } from 'src/app/shared/services/tuning.service';

@Component({
  selector: 'app-tuning-card',
  templateUrl: './tuning-card.component.html',
  styleUrls: ['./tuning-card.component.scss']
})
export class TuningCardComponent {

  @Input() tuning!: TuningDto;
  @Output() rerender = new EventEmitter();
  mouseOn: boolean = false;

  constructor(
    private readonly tuningService: TuningService,
    public dialog: MatDialog) { }

  editTuning() {
    const dialogRef = this.dialog.open(EditTuningDialogComponent, {
      width: '300px',
      data: this.tuning,
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          this.handleEdit(result);
        }
      })
  }

  handleEdit(result: FormGroup) {
    this.tuning.name = result.controls["name"].value;
    this.tuning.strings = result.controls["strings"].value;
    this.tuning.stringNumber = result.controls["stringNumber"].value;
    this.tuning.instrument = result.controls["instrument"].value;

    this.tuningService.editTuning(this.tuning)
      .subscribe(response => {
        this.tuning = response.object;
        this.rerender.emit({tuning: this.tuning});
      });
  }

  deleteTuning() {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '400px',
      data: { name: this.tuning.name },
    });

    dialogRef
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.handleDelete()
        }
      })
  }

  handleDelete() {
    this.tuningService.deleteTuning(this.tuning.id)
      .subscribe(_response => this.rerender.emit({id: this.tuning.id}));
  }
}
