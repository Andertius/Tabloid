import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  @Output() rerenderAfterDelete = new EventEmitter<string>();
  @Output() rerenderAfterEdit = new EventEmitter<GenreDto>();
  @Output() rerenderAfterAdd = new EventEmitter<GenreDto>();
  mouseOn: boolean = false;

  constructor(
    private readonly genreService: GenreService,
    public dialog: MatDialog,
    private readonly snackBar: MatSnackBar) { }

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
    const copy: GenreDto = JSON.parse(JSON.stringify(this.genre));
    this.genre.name = name;
    this.genreService.editGenre(this.genre)
      .subscribe(response => {
        this.genre = response.object;
        this.rerenderAfterEdit.emit(this.genre);
        const snackBarRef = this.snackBar.open('Genre updated', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.genreService.editGenre(copy)
            .subscribe(anotherResponse => {
              this.genre = anotherResponse.object;
              this.rerenderAfterEdit.emit(this.genre);
            })
        });
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
      .subscribe(_response => {
        this.rerenderAfterDelete.emit(this.genre.id);

        const snackBarRef = this.snackBar.open('Genre deleted', 'Undo', { duration: 3000 });

        snackBarRef.onAction().subscribe(() => {
          this.genreService.addGenre(this.genre)
            .subscribe(anotherResponse => {
              this.genre = anotherResponse.object;
              this.rerenderAfterAdd.emit(this.genre);
            })
        });
      });
  }
}
