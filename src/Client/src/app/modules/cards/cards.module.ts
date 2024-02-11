import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistCardComponent } from './components/artist-card/artist-card.component';
import { MaterialModule } from 'src/app/shared/modules/material/material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AlbumCardComponent } from './components/album-card/album-card.component';
import { TrackListItemAlbumComponent } from './components/track-list-item-album/track-list-item-album.component';
import { TrackListItemComponent } from './components/track-list-item/track-list-item.component';
import { AlbumCardArtistComponent } from './components/album-card-artist/album-card-artist.component';
import { TrackListItemArtistComponent } from './components/track-list-item-artist/track-list-item-artist.component';
import { GenreCardComponent } from './components/genre-card/genre-card.component';
import { TuningCardComponent } from './components/tuning-card/tuning-card.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TabCardComponent } from './components/tab-card/tab-card.component';

@NgModule({
  declarations: [
    ArtistCardComponent,
    AlbumCardComponent,
    TrackListItemAlbumComponent,
    TrackListItemComponent,
    AlbumCardArtistComponent,
    TrackListItemArtistComponent,
    GenreCardComponent,
    TuningCardComponent,
    TabCardComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    AppRoutingModule,
    SharedModule,
  ],
  exports: [
    ArtistCardComponent,
    AlbumCardComponent,
    TrackListItemAlbumComponent,
    TrackListItemComponent,
    AlbumCardArtistComponent,
    TrackListItemArtistComponent,
    GenreCardComponent,
    TuningCardComponent,
    TabCardComponent,
  ]
})
export class CardsModule { }
