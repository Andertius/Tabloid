import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { ArtistComponent } from './components/artist/artist.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AlbumComponent } from './components/album/album.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MaterialModule } from 'src/app/shared/modules/material/material.module';
import { CardsModule } from '../cards/cards.module';
import { ArtistsComponent } from './components/artists/artists.component';
import { AlbumsComponent } from './components/albums/albums.component';
import { GenresComponent } from './components/genres/genres.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TuningsComponent } from './components/tunings/tunings.component';
import { SongComponent } from './components/song/song.component';
import { SongsComponent } from './components/songs/songs.component';

@NgModule({
  declarations: [
    HomeComponent,
    AlbumComponent,
    ArtistComponent,
    ArtistsComponent,
    AlbumsComponent,
    GenresComponent,
    TuningsComponent,
    SongComponent,
    SongsComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    SharedModule,
    MaterialModule,
    CardsModule,
    ReactiveFormsModule,
  ],
  exports: [
    HomeComponent,
    AlbumComponent,
    ArtistComponent,
    ArtistsComponent,
    AlbumsComponent,
    GenresComponent,
    SongComponent,
    SongsComponent,
  ]
})
export class MainModule { }
