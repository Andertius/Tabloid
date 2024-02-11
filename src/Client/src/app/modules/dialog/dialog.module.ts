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
import { EditTabDialogComponent } from './components/tabs/edit-tab-dialog/edit-tab-dialog.component';
import { AddArtistDialogComponent } from './components/artists/add-artist-dialog/add-artist-dialog.component';
import { AddAlbumDialogComponent } from './components/albums/add-album-dialog/add-album-dialog.component';
import { AddSongDialogComponent } from './components/songs/add-song-dialog/add-song-dialog.component';
import { EditAlbumDialogComponent } from './components/albums/edit-album-dialog/edit-album-dialog.component';
import { EditArtistDialogComponent } from './components/artists/edit-artist-dialog/edit-artist-dialog.component';

@NgModule({
  declarations: [
    DeleteDialogComponent,
    EditSongDialogComponent,
    AddGenreDialogComponent,
    EditGenreDialogComponent,
    AddTuningDialogComponent,
    EditTuningDialogComponent,
    AddTabDialogComponent,
    EditTabDialogComponent,
    AddArtistDialogComponent,
    AddAlbumDialogComponent,
    AddSongDialogComponent,
    EditAlbumDialogComponent,
    EditArtistDialogComponent,
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
    EditTuningDialogComponent,
    AddTabDialogComponent,
    EditTabDialogComponent,
    AddArtistDialogComponent,
    AddAlbumDialogComponent,
    EditAlbumDialogComponent,
  ]
})
export class DialogModule { }
