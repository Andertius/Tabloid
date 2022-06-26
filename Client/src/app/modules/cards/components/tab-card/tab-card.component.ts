import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { TabService } from 'src/app/shared/services/tab.service';

@Component({
  selector: 'app-tab-card',
  templateUrl: './tab-card.component.html',
  styleUrls: ['./tab-card.component.scss']
})
export class TabCardComponent {
  
  @Input() tab!: TabDto;
  @Output() rerender = new EventEmitter();
  mouseOn: boolean = false;

  constructor(
    private readonly tabService: TabService,
    public dialog: MatDialog) { }

  editTab() {

  }

  deleteTab() {

  }

}
