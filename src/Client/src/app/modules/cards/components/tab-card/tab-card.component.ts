import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { DeleteDialogComponent } from 'src/app/modules/dialog/components/delete-dialog/delete-dialog.component';
import { EditTabDialogComponent } from 'src/app/modules/dialog/components/tabs/edit-tab-dialog/edit-tab-dialog.component';
import { TabService } from 'src/app/shared/services/tab.service';

@Component({
  selector: 'app-tab-card',
  templateUrl: './tab-card.component.html',
  styleUrls: ['./tab-card.component.scss']
})
export class TabCardComponent {
  
  @Input() tab!: TabDto;
  @Output() rerenderAfterDelete = new EventEmitter();
  @Output() rerenderAfterEdit = new EventEmitter();
  mouseOn: boolean = false;

  constructor(
    private readonly tabService: TabService,
    public dialog: MatDialog) { }

  editTab() {
    const dialogRef = this.dialog.open(EditTabDialogComponent, {
      width: '400px',
      data: this.tab,
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
    console.log(this.tab)
    this.tab.name = result.controls["name"].value;
    this.tab.link = result.controls["link"].value;
    this.tab.difficulty = result.controls["difficulty"].value;
    this.tab.tuning = result.controls["tuning"].value;

    this.tabService.editTab(this.tab)
      .subscribe(response => {
        this.tab = response.object;
        this.rerenderAfterEdit.emit({tab: this.tab});
      });
  }

  deleteTab() {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: { name: this.tab.name },
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
    this.tabService.deleteTab(this.tab.id)
      .subscribe(_response => this.rerenderAfterDelete.emit({id: this.tab.id}));
  }

}
