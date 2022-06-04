import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistCardComponent } from './components/artist-card/artist-card.component';
import { MaterialModule } from 'src/app/shared/modules/material/material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AlbumCardComponent } from './components/album-card/album-card.component';

@NgModule({
  declarations: [
    ArtistCardComponent,
    AlbumCardComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    AppRoutingModule
  ]
})
export class CardsModule { }
