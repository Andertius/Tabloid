import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumCardComponent } from './modules/cards/components/album-card/album-card.component';
import { ArtistCardComponent } from './modules/cards/components/artist-card/artist-card.component';
import { AlbumComponent } from './modules/main/components/album/album.component';
import { ArtistComponent } from './modules/main/components/artist/artist.component';
import { HomeComponent } from './modules/main/components/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'artist-card', component: ArtistCardComponent },
  { path: 'album-card', component: AlbumCardComponent },
  { path: 'artist/:id', component: ArtistComponent },
  { path: 'album/:id', component: AlbumComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home', },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
