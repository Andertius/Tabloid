import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  @Output() rerenderAfterEdit = new EventEmitter<TuningDto>();
  @Output() rerenderAfterDelete = new EventEmitter<string>();
  @Output() rerenderAfterAdd = new EventEmitter<TuningDto>();
  mouseOn: boolean = false;

  constructor(
    private readonly tuningService: TuningService,
    public dialog: MatDialog,
    private readonly snackBar: MatSnackBar) { }

  editTuning() {
    const dialogRef = this.dialog.open(EditTuningDialogComponent, {
      width: '400px',
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
    const copy: TuningDto = JSON.parse(JSON.stringify(this.tuning));
    this.tuning.name = result.controls["name"].value;
    this.tuning.strings = result.controls["strings"].value;
    this.tuning.stringNumber = result.controls["stringNumber"].value;
    this.tuning.instrument = result.controls["instrument"].value;

    this.tuningService.editTuning(this.tuning)
      .subscribe(response => {
        this.tuning = response.object;
        this.rerenderAfterEdit.emit(this.tuning);
        const snackBarRef = this.snackBar.open('Tuning updated', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.tuningService.editTuning(copy)
            .subscribe(anotherResponse => {
              this.tuning = anotherResponse.object;
              this.rerenderAfterEdit.emit(this.tuning);
            })
        });
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
      .subscribe(_response => {
        this.rerenderAfterDelete.emit(this.tuning.id);
        
        const snackBarRef = this.snackBar.open('Tuning deleted', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.tuningService.addTuning(this.tuning)
            .subscribe(anotherResponse => {
              this.tuning = anotherResponse.object;
              this.rerenderAfterAdd.emit(this.tuning);
            })
        });
      });
  }
}
