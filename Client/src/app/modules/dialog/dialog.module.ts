import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';
import { EditSongDialogComponent } from './components/songs/edit-song-dialog/edit-song-dialog.component';
import { MaterialModule } from 'src/app/shared/modules/material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddGenreDialogComponent } from './components/genres/add-genre-dialog/add-genre-dialog.component';
import { EditGenreDialogComponent } from './components/genres/edit-genre-dialog/edit-genre-dialog.component';
import { AddTuningDialogComponent } from './components/tunings/add-tuning-dialog/add-tuning-dialog.component';
import { EditTuningDialogComponent } from './components/tunings/edit-tuning-dialog/edit-tuning-dialog.component';
import { AddTabDialogComponent } from './components/tabs/add-tab-dialog/add-tab-dialog.component';

@NgModule({
  declarations: [
    DeleteDialogComponent,
    EditSongDialogComponent,
    AddGenreDialogComponent,
    EditGenreDialogComponent,
    AddTuningDialogComponent,
    EditTuningDialogComponent,
    AddTabDialogComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [
    DeleteDialogComponent,
    EditSongDialogComponent,
    AddGenreDialogComponent,
    EditGenreDialogComponent,
    AddTuningDialogComponent,
    AddTuningDialogComponent,
    EditTuningDialogComponent,
  ]
})
export class DialogModule { }
