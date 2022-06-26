import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { GenreDto } from 'src/app/models/dtos/genre.dto';
import { DeleteDialogComponent } from 'src/app/modules/dialog/components/delete-dialog/delete-dialog.component';
import { EditGenreDialogComponent } from 'src/app/modules/dialog/components/genres/edit-genre-dialog/edit-genre-dialog.component';
import { GenreService } from 'src/app/shared/services/genre.service';

@Component({
  selector: 'app-genre-card',
  templateUrl: './genre-card.component.html',
  styleUrls: ['./genre-card.component.scss']
})
export class GenreCardComponent {

  @Input() genre!: GenreDto;
  @Output() rerender = new EventEmitter();
  mouseOn: boolean = false;

  constructor(
    private readonly genreService: GenreService,
    public dialog: MatDialog) { }

  editGenre() {
    const dialogRef = this.dialog.open(EditGenreDialogComponent, {
      width: '300px',
      data: this.genre,
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          this.handleEdit(result.controls["name"].value);
        }
      })
  }

  handleEdit(name: string) {
    this.genre.name = name;
    this.genreService.editGenre(this.genre)
      .subscribe(response => {
        this.genre = response.object;
        this.rerender.emit({genre: this.genre});
      });
  }

  deleteGenre() {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: { name: this.genre.name },
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
    this.genreService.deleteGenre(this.genre.id)
      .subscribe(_response => this.rerender.emit({id: this.genre.id}));
  }
}
