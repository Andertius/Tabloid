import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { ArtistComponent } from './components/artist/artist.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AlbumComponent } from './components/album/album.component';



@NgModule({
  declarations: [
    HomeComponent,
    ArtistComponent,
    AlbumComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
  ],
  exports: [
    HomeComponent,
    ArtistComponent,
  ]
})
export class MainModule { }
